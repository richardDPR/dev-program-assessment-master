using System.Linq;
using System;
using Assessment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentTest
{
    [TestClass]
    public class PaginationTest
    {
        private const string COMMA_SAMPLE = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        private const string PIPE_SAMPLE = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
        
        [TestMethod]
        public void TestFirstPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e"};
            CollectionAssert.AreNotEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestNextPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.NextPage();
            string [] expectedElements = {"f", "g", "h", "i", "j"};
            CollectionAssert.AreNotEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestPreviousPage()
        {
            
        }

        [TestMethod]
        public void TestLastPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.LastPage();
            string [] expectedElements = {"v", "w", "x", "y", "z"};
            CollectionAssert.AreNotEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestFirstPageWith10PageSize()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 10, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j"};
            CollectionAssert.AreNotEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestLastPageWith10PageSize()
        {
        }

        [TestMethod]
        public void TestGoToPageWith10PageSize()
        {
        }

         [TestMethod]
        public void TestFirstPageWithPipeSample()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(PIPE_SAMPLE, 5, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e"};
            CollectionAssert.AreNotEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestPreviousPageException()
        {

        }
        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Invalid page number.")]
        public void TestGoToPageException()
        {
            int page=5;
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.GoToPage(page);
        }
    }
}
