using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace JokesWebApp.Models
{
    public class Request_Mental_Health
    {
        public int Id { get; set; }

        public String UserName { get; set; }

        public DateTime Date { get; set; }
        public Request_Mental_Health()
        {

        }
    }
}
