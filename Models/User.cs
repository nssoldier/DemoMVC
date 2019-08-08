using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoMVC.Models
{
  public class User
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    public string LastName { get; set; }
  }
}
