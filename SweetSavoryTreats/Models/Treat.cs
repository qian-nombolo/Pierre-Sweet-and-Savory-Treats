using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetSavoryTreats.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "The Treat's Name is the most important information!")]
    public string TreatName { get; set; }
    public string TreatIngredient { get; set; }

    [Required(ErrorMessage = "The Treat Rate is required!")]
    public string TreatRate { get; set; }

    public List<TreatFlavor> JoinEntities { get; set; }

    public ApplicationUser User { get; set; } 
  }
}