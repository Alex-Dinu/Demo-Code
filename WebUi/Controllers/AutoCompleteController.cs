using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.GetSomeData;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class AutoCompleteController : Controller
    {
        private List<string> _states;

        public List<string> States
        {
            get
            {
                if (_states == null)
                    _states = GetStates();
                return _states;
            }

        }

        private List<string> GetStates()
        {
            List<string> states = new List<string>()
                { "Alabama", "Alaska", "American Samoa", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District Of Columbia", "Federated States Of Micronesia", "Florida", "Georgia", "Guam", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Marshall Islands", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Northern Mariana Islands", "Ohio", "Oklahoma", "Oregon", "Palau", "Pennsylvania", "Puerto Rico", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virgin Islands", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };

            return states;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public string GetJQueryStates()
        {
                return "Alabama,Alaska,American Samoa,Arizona,Arkansas,California,Colorado,Connecticut,Delaware,District Of Columbia,Federated States Of Micronesia,Florida,Georgia,Guam,Hawaii,Idaho,Illinois,Indiana,Iowa,Kansas,Kentucky,Louisiana,Maine,Marshall Islands,Maryland,Massachusetts,Michigan,Minnesota,Mississippi,Missouri,Montana,Nebraska,Nevada,New Hampshire,New Jersey,New Mexico,New York,North Carolina,North Dakota,Northern Mariana Islands,Ohio,Oklahoma,Oregon,Palau,Pennsylvania,Puerto Rico,Rhode Island,South Carolina,South Dakota,Tennessee,Texas,Utah,Vermont,Virgin Islands,Virginia,Washington,West Virginia,Wisconsin,Wyoming";

        }

        //[HttpGet]
        //// [ValidateAntiForgeryToken]
        //public string JQueryAutoComplete(string searchValue)
        //{

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<select id=\"autoCompleteSelect\" size=\"5\">");

        //    foreach (string state in States)
        //    {
        //        if (state.IndexOf(searchValue, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
        //            sb.Append("<option value=\"" + state + "\">" + state + "</option>");
        //    }

        //    sb.Append("</select>");
        //    return sb.ToString();
        //}


        [HttpGet]
       // [ValidateAntiForgeryToken]
        public string MvcAutoComplete(string searchValue)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<select id='autoCompleteSelect' size='5'>");

            foreach (string state in States)
            {
                if (state.IndexOf(searchValue, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    sb.Append("<option>" + state + "</option>");
            }

            sb.Append("</select>");
            return sb.ToString();



            //StringBuilder sb = new StringBuilder();
            //sb.Append("<select id=\"autoCompleteSelect\" size=\"5\">");

            //foreach (string state in States)
            //{
            //    if (state.IndexOf(searchValue, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            //        sb.Append("<option value=\"" + state + "\">" + state + "</option>");
            //}

            //sb.Append("</select>");
            //return sb.ToString();

            //Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            //dataDictionary.Add("jQuery Validation of Email, Number, Checkbox and More", "http://www.yogihosting.com/using-jquery-to-validate-a-form/");
            //dataDictionary.Add("jQuery Uncheck Checkbox Tutorial", "http://www.yogihosting.com/check-uncheck-all-checkbox-using-jquery/");
            //dataDictionary.Add("Free WordPress Slider Built In jQuery", "http://www.yogihosting.com/wordpress-image-slider-effect-with-meta-slider/");
            //dataDictionary.Add("Creating jQuery Expand Collapse Panels In HTML", "http://www.yogihosting.com/creating-expandable-collapsible-panels-in-jquery/");
            //dataDictionary.Add("jQuery AJAX Events Complete Guide for Beginners and Experts", "http://www.yogihosting.com/jquery-ajax-events/");
            //dataDictionary.Add("How to Create a Web Scraper in ASP.NET MVC and jQuery", "http://www.yogihosting.com/web-scraper/");
            //dataDictionary.Add("CRUD Operations in Entity Framework and ASP.NET MVC", "http://www.yogihosting.com/crud-operations-entity-framework/");
            //dataDictionary.Add("Implementing TheMovieDB (TMDB) API in ASP.NET MVC", "http://www.yogihosting.com/implement-themoviedb-api/");
            //dataDictionary.Add("ASP.NET MVC Data Annotation – Server Side Validation of Controls", "http://www.yogihosting.com/server-side-validation-asp-net-mvc/");
            //dataDictionary.Add("How to use CKEditor in ASP.NET MVC", "http://www.yogihosting.com/ckeditor-tutorial-asp-net-mvc/");

            //StringBuilder sb = new StringBuilder();
            //sb.Append("<select id=\"autoCompleteSelect\" size=\"5\">");

            //foreach (KeyValuePair<string, string> entry in dataDictionary)
            //{
            //    if (entry.Key.IndexOf(searchValue, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            //        sb.Append("<option value=\"" + entry.Value + "\">" + entry.Key + "</option>");
            //}

            //sb.Append("</select>");
            //return sb.ToString();
        }

       private List<string> GetAutocompleteStates(string value)
       {
           var states = States.Where(s => s.Contains(value)).ToList();
            return states;

       }



    }
}