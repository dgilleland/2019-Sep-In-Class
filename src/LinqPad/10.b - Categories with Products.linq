<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from cat in Categories
select new // ProductCategory
{
    CategoryName = cat.CategoryName,
    Description = cat.Description,
    Picture = cat.Picture.ToImage(), // note: remove .ToImage() for vs2019
    MimeType = cat.PictureMimeType,
    Products =  from item in cat.Products
                select new // ProductSummary
                {
                    Name = item.ProductName,
                    Price = item.UnitPrice,
                    Quantity = item.QuantityPerUnit
                }
}
 