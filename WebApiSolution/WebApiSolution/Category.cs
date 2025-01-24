namespace Domain

/* 
Implement the Product and Category models in the Domain class library.

Category Domain Class:

Id:
Type: Integer
Description: Unique identifier for the category.

Name:
Type: String
Description: Name of the category. ???

 */ */

{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}