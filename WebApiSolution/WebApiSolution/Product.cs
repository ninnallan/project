namespace Domain
/* Models:
Implement the Product and Category models in the Domain class library.

Product Domain Class:

Id: 
Type: Integer
Description: Unique identifier for the product.

Name:
Type: String
Description: Name of the product.

Price:
Type: Decimal
Description: Price of the product.

CategoryId:
Type: Integer
Description: Identifier indicating the category to which the product belongs.


 */

{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}