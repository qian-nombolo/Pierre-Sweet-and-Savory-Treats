using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetSavoryTreats.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    [Required(ErrorMessage = "The order's treats can't be empty!")]
    public string OrderContent { get; set; } 
    [Required(ErrorMessage = "The order's amount is required!")]  
    public string OrderAmount { get; set; }
    public string OrderDescription { get; set; }

    public List<OrderTreat> OTJoinEntities { get; set; }

    public ApplicationUser User { get; set; }
  }
}