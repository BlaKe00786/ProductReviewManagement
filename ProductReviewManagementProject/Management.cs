using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementProject
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProducID == 1 || productReviews.ProducID == 4 || productReviews.ProducID == 9)
                               && productReviews.Rating > 3
                               select productReviews;
            Console.WriteLine("Rating greater than 3 with product id of 1,4 or 9 :-");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            Console.WriteLine("ID with Count");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "--------" + list.Count);
            }
        }
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { ProductID = x.ProducID, Review = x.Review });
            Console.WriteLine("ID with Review");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "--------" + list.Review);
            }
        }
        public void skipFiveRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            Console.WriteLine("Top Records skiping top 5 rated records- ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
        public DataTable CreateDataTable()
        {
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("UserID");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike");
            return dataTable;
        }
        public void RetrieveRecordsWithisLikeTrue(DataTable table)
        {
            var recordedData = from productReviews in table.AsEnumerable()
                               where (productReviews.Field<bool>("isLike") == true)
                               select productReviews;
            Console.WriteLine("Records with isLike=true are :-");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.Field<int>("ProductID") + " " + "UserID:- " + list.Field<int>("UserID")
                    + " " + "Rating:- " + list.Field<double>("Rating") + " " + "Review:- " + list.Field<string>("Review") + " " + "isLike:- " + list.Field<bool>("isLike"));
            }
        }
    }
}
