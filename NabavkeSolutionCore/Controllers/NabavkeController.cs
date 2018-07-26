using System;
using System.Collections.Generic;
using System.Linq;
using NabavkeSolutionCore.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NabavkeSolutionCore.Controllers.Resourses;
using NabavkeSolutionCore.Data.Persistence;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using Microsoft.Extensions.Logging;
using static CirToLat_NetStandard2.CirToLat;

namespace NabavkeSolutionCore.Controllers
{
    
    public class NabavkeController : Controller
    {
        public readonly NabavkeSolutionCoreDbContext db;
        private readonly IMapper mapper;
        private readonly INotificationHandler notification;
        private readonly ILogger<NabavkeController> _logger;

        public NabavkeController( 
            NabavkeSolutionCoreDbContext db
            ,IMapper mapper
            ,INotificationHandler notification,ILogger<NabavkeController> logger
            )
        {
            this.db = db;
            this.mapper = mapper;
            this.notification = notification;
            _logger = logger;
        }

        // GET: api/Nabavke
        [HttpGet]
        [Route("api/nabavke")]
        public IActionResult GetNabavke()
        {
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .ToList();
            return Ok(mapper.Map<List<Nabavka>, List<NabavaShortDto>>(nabavke));
        }
        [HttpGet]
        [Route("api/nabavkem")]
        public IActionResult GetNabavke2()
        {
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .ToList();

            return Ok(mapper.Map<List<Nabavka>, List<NabavkaMediumDto>>(nabavke));
        }
        // GET: api/Nabavke/{predmet}
        [Route("api/nabavke/{predmet}")]
        public IActionResult GetNabavke(string predmet)
        {
            
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.VrstaPredmeta.Contains(predmet))
                .ToList()
                .Select(Mapper.Map<Nabavka, NabavaShortDto>);
            return Ok(nabavke);
        }

        [Route("api/nabavkem/{predmet}")]
        public IActionResult GetNabavke2(string predmet)
        {
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.VrstaPredmeta.Contains(predmet))
                .OrderByDescending(n => n.DatumPoslednjeIzmene)
                .ToList()
                .Select(Mapper.Map<Nabavka, NabavkaMediumDto>);
            return Ok(nabavke);
        }
        [Route("api/nabavkem/array/{sifre}")]
        public IActionResult GetNabavke3(string sifre)
        {
            List<NabavkaMediumDto> nabavke = new List<NabavkaMediumDto>();
            var array = sifre.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (var a in array)
            {
                var i = Convert.ToInt32(a);
                nabavke.Add(db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.SifraNabavke == i)
                .OrderByDescending(n => n.DatumPoslednjeIzmene)
                .Select(Mapper.Map<Nabavka, NabavkaMediumDto>)
                .Single());
            }
            return Ok(nabavke.AsEnumerable());
        }
        [Route("api/nabavkem/{predmet}/{serija}")]
        public IActionResult GetNabavke2(string predmet, int serija)
        {
            serija--;
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.VrstaPredmeta.Contains(predmet))
                .OrderByDescending(n => n.DatumPoslednjeIzmene)
                .ToList().Skip(serija * 100).Take(100)
                .Select(Mapper.Map<Nabavka, NabavkaMediumDto>);
            return Ok(nabavke);
        }
        [Route("api/nabavkem/{predmet}/search/{search}")]
        public IActionResult GetNabavke2(string predmet, string search)
        {
            search = Preved(search, PrevodNa.Cirilica);
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.VrstaPredmeta.Contains(predmet))
                .Where(n => n.NazivDokumenta.Contains(search) || n.NazivDokumenta.ToLower().Contains(search)
                || n.NazivNarucioca.Contains(search) || n.NazivNarucioca.ToLower().Contains(search)
                || n.Mesto.Naziv.Contains(search) || n.Mesto.Naziv.ToLower().Contains(search)
                || n.DatumPoslednjeIzmene.Value.ToString().Contains(search))
                .OrderByDescending(n => n.DatumPoslednjeIzmene)
                .ToList()
                .Select(Mapper.Map<Nabavka, NabavkaMediumDto>);
            return Ok(nabavke);
        }
        [Route("api/nabavkem/{predmet}/search/{search}/{serija}")]
        public IActionResult GetNabavke2(string predmet, string search, int serija)
        {
            search = Preved(search, PrevodNa.Cirilica);
            serija--;
            var nabavke = db.Nabavke
                .Include(n => n.Mesto)
                .Where(n => n.VrstaPredmeta.Contains(predmet))
                .Where(n => n.NazivDokumenta.Contains(search) || n.NazivDokumenta.ToLower().Contains(search)
                || n.NazivNarucioca.Contains(search) || n.NazivNarucioca.ToLower().Contains(search)
                || n.Mesto.Naziv.Contains(search) || n.Mesto.Naziv.ToLower().Contains(search)
                || n.SifraNabavke.ToString().Contains(search)
                || n.DatumPoslednjeIzmene.Value.ToString().Contains(search))
                .OrderByDescending(n => n.DatumPoslednjeIzmene)
                .ToList().Skip(serija * 100).Take(100)
                .Select(Mapper.Map<Nabavka, NabavkaMediumDto>);
            return Ok(nabavke);
        }
        [Route("api/nabavkem/info")]
        public IActionResult GetInfo()
        {
            InfoOfUpdates info = new InfoOfUpdates
            {
                LastUpdated = db.UpdateDblogs.Where(u => u.StatusMessage.Contains("Success")).Max(u => u.End),
                Dobra = db.Nabavke.Where(n => n.VrstaPredmeta == "добра").Count(),
                Usluge = db.Nabavke.Where(n => n.VrstaPredmeta == "услуге").Count(),
                Radovi = db.Nabavke.Where(n => n.VrstaPredmeta == "радови").Count(),
            };
            return Ok(info);
        }


        [AuthenticationFilter]
        [HttpPost]
        [Route("api/nabavke/test/")]
        public IActionResult test()
        {
            //this.HttpContext.Items.Add(new { db = "db" },db);
            var d = notification.GetDevices();
            if (d != null)
            {
                var playersIdArray = new List<string> { };
                foreach (var device in d.players)
                {
                    if (device.tags.Any(tag => tag.Key == "notif" && tag.Value == "false")) continue;// if u desable notif in app settings
                    foreach (KeyValuePair<string, string> tag in device.tags)
                    {
                        if (tag.Key.Contains("follow"))
                        {
                            var tagVal = Convert.ToInt32(tag.Value);
                            if (db.NabavkeUpdate.Any(n => n.SifraNabavke == tagVal))
                            {
                                if (!playersIdArray.Any(n => n == device.id))
                                    playersIdArray.Add(device.id);
                            }
                        }

                    }
                }
                if (playersIdArray.Count() != 0)
                {
                    var resp = notification.CreateNotifications("Nabavka koju pratite je ažurirana!", playersIdArray.ToArray());
                    if (resp == null)
                        return BadRequest("no notificatins created!");
                    _logger.LogInformation("notification created!");
                    return Ok("notification created!");
                }

            }
            _logger.LogInformation("no notificatins created!");
            return Ok("no notificatins created!");
        }
    }

}