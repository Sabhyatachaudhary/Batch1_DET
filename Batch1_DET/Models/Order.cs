using Batch1_DET.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("MyOrder")]
public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Order_ID { get; set; }

    public DateTime OrderDate { get; set; }

    [Column("OrderAmt")]
    public int Amount { get; set; }

    public Customer cust { get; set; } //navigation prop
}