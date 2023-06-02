using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SweetSavoryTreats.Models
{
  
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "The Flavor's name can't be empty!")]
    public string FlavorName { get; set; }

    public List<TreatFlavor> JoinEntities { get;}
    
    public ApplicationUser User { get; set; }
  }
}