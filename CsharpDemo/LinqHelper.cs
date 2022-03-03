using CsharpDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    public class LinqHelper
    {

        public static List<CustomerFXDto> UnionData()
        {

            var listOne = new List<CustomerFXDto>
                        {
                            new CustomerFXDto
                            {
                                Id = 1,
                                  ShopName = "ShopName1",
                                  RealName =  "RealName1"
                            },
                            new CustomerFXDto
                            {
                                Id=2,

                                  ShopName = "ShopName2",
                                  RealName= "RealName2"

                            }
                        };

            var listTwo = new List<CustomerFXDto>
                        {
                            new CustomerFXDto
                            {
                                  Id=3,
                                  ShopName =null,
                                  RealName= "RealName3"
                            },
                            new CustomerFXDto
                            {
                                 Id=4,
                                  ShopName ="ShopName4",
                                  RealName= null
                            }
                        };

            //合并
            var query = listOne.AsQueryable().Concat(listTwo.AsQueryable());

            var unionList = query.ToList();

            return unionList;

        }
    }
}
