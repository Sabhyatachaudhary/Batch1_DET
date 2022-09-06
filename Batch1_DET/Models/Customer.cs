using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("Customer")]
public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Required()]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    public virtual ICollection<Order> Orders { get; set; } //navigation prop
}