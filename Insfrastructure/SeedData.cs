using Microsoft.EntityFrameworkCore;
using Shopping.Models;


namespace Shopping.Insfrastructure

{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            
            if(!context.Products.Any())
            {
                Category A = new Category { Name = "Váy cưới chữ A", Slug="A" };
                Category Classic = new Category { Name = "Váy cưới cổ điển", Slug="Classic" };
                Category Fish = new Category { Name = "Váy cưới đuôi cá", Slug = "Fish" };
                Category Modern = new Category { Name = "Váy cưới hiện đại", Slug = "Modern" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Q7 VNCS 38",
                            Slug="SP_38",
                            Description= "Kiểu váy cưới chữ A với phôm dáng vừa vặn với cơ thể cùng phần váy xoè hình chữ A giúp cô dâu che khuyết điểm. Chúng phù hợp với bất kì thân hình nào nên luôn là lựa chọn tuyệt vời nhất.",
                            Price = 6.00M,
                            Category = A,
                            Image="1.jpg"
                        },
                        new Product
                        {
                            Name = "Q7 VNCC 10",
                            Slug="SP_10",
                            Description= "Sức hút của kiểu váy cưới đuôi cá khiến các nàng dâu đều muốn được diện trong ngày cưới của mình. Mẫu váy này là sự kết hợp độc đáo giữa quyến rũ và sang trọng. Nó khiến cho người mặc trở nên bí ẩn và quyền lực hơn.",
                            Price = 8.00M,
                            Category = Fish,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCC 6",
                            Slug="SP_6",
                            Description= "Sức hút của kiểu váy cưới đuôi cá khiến các nàng dâu đều muốn được diện trong ngày cưới của mình. Mẫu váy này là sự kết hợp độc đáo giữa quyến rũ và sang trọng. Nó khiến cho người mặc trở nên bí ẩn và quyền lực hơn",
                            Price = 8.00M,
                            Category = Fish,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCL 90",
                            Slug="SP_90",
                            Description= "Chiếc váy cưới xoè công chúa khiến cho bạn trở nên lộng lẫy, sang trọng hơn bao giờ hết. Dù đã xuất hiện từ lâu nhưng kiểu dáng này luôn là lựa chọn yêu thích nhất. Sở hữu phom dáng cổ điển, chưa bao giờ lỗi thời. Váy cưới xòe là kiểu thiết kế với thân trên ôm sát cơ thể, từ phần eo trở xuống xòe ra",
                            Price = 20.00M,
                            Category = Modern,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCL 8",
                            Slug="SP_8",
                            Description= "Chiếc váy cưới xoè công chúa khiến cho bạn trở nên lộng lẫy, sang trọng hơn bao giờ hết. Dù đã xuất hiện từ lâu nhưng kiểu dáng này luôn là lựa chọn yêu thích nhất. Sở hữu phom dáng cổ điển, chưa bao giờ lỗi thời. Váy cưới xòe là kiểu thiết kế với thân trên ôm sát cơ thể, từ phần eo trở xuống xòe ra",
                            Price = 20.00M,
                            Category = Modern,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCS 9",
                            Slug="SP_9",
                            Description= "Có thể nói đây là kiểu dáng phù hợp với nhiều dáng người nhất. Chẳng những mang đến sự thoải mái thậm chí nó đang là xu hướng. Váy cưới suông chữ A mang lại sự thanh lịch, nhẹ nhàng, tự nhiên cho nàng dâu",
                            Price = 6.00M,
                            Category = A,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCXM 12",
                            Price = 8.00M,
                            Slug= "SP_12",
                            Description= "Chiếc váy cưới xoè công chúa khiến cho bạn trở nên lộng lẫy, sang trọng hơn bao giờ hết. Dù đã xuất hiện từ lâu nhưng kiểu dáng này luôn là lựa chọn yêu thích nhất. Sở hữu phom dáng cổ điển, chưa bao giờ lỗi thời. Váy cưới xòe là kiểu thiết kế với thân trên ôm sát cơ thể, từ phần eo trở xuống xòe ra",
                            Category = Classic,
                            Image = "1.jpg"

                        },
                        new Product
                        {
                            Name = "Q7 VNCXM 5",
                            Slug="SP_5",
                            Price = 8.00M,
                            Description= "Chiếc váy cưới xoè công chúa khiến cho bạn trở nên lộng lẫy, sang trọng hơn bao giờ hết. Dù đã xuất hiện từ lâu nhưng kiểu dáng này luôn là lựa chọn yêu thích nhất. Sở hữu phom dáng cổ điển, chưa bao giờ lỗi thời. Váy cưới xòe là kiểu thiết kế với thân trên ôm sát cơ thể, từ phần eo trở xuống xòe ra",
                            Category = Classic,
                            Image = "1.jpg"

                        }
                );

                context.SaveChanges();
            }
        }
    }
}
