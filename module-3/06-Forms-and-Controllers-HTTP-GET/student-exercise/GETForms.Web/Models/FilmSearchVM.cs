using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GETForms.Web.Models
{
    public class FilmSearchVM
    {
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
        public IList<Film> Films { get; set; }
        //public IList<string> Genres { get; set; }

        //public void AddGenres(IList<string> newGenres)
        //{
        //    foreach (string genre in newGenres)
        //    {
        //        GenreList.Add(new SelectListItem { Text = genre, Value = genre });
        //    }
        //}

        public SelectList GenreList { get; set; }
    }
}
