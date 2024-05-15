using System.Drawing;
using System.Drawing.Imaging;
using ZONOupdate.Database;
using ZONOupdate.Forms.FormForCreationNewProduct;
using ZONOupdate.FunctionalClasses;

namespace TestProject
{
    [TestClass]
    public class ZONOUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] byteArray;

            using (var memoryStream = new MemoryStream())
            {
                using (var bitmap = new Bitmap(1, 1))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.White);
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);
                        byteArray = memoryStream.ToArray();
                    }
                }
            }

            var result = CustomImageConverter.ByteArrayToImage(byteArray);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            byte[] byteArray;

            using (var memoryStream = new MemoryStream())
            {
                using (var bitmap = new Bitmap(1, 1))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.White);
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);
                        byteArray = memoryStream.ToArray();
                    }
                }
            }

            var result = CustomImageConverter.ByteArrayToImage(byteArray);

            Assert.IsInstanceOfType(result, typeof(Bitmap));
        }
        [TestMethod]
        public void TestMethod3()
        {
            var realPassword = "password1";
            var hashedPassword = "7C6A180B36896A0A8C02787EEAFB0E4C";

            Assert.IsTrue(hashedPassword.Equals(DataEncryption.HashingData(realPassword)));
        }
        [TestMethod]
        public void TestMethod4()
        {
            var realPassword = "password1";

            Assert.IsNotNull(DataEncryption.HashingData(realPassword));
        }
        [TestMethod]
        public void TestMethod5()
        {
            byte[] byteArray;

            using (var memoryStream = new MemoryStream())
            {
                using (var bitmap = new Bitmap(1, 1))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.White);
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);
                        byteArray = memoryStream.ToArray();
                    }
                }
            }

            var result = CustomImageConverter.ByteArrayToImage(byteArray);

            Assert.AreNotEqual(typeof(CustomImageConverter), typeof(Bitmap));
        }
        [TestMethod]
        public void TestMethod6()
        {
            var realPassword = "password1";
            var hashedPassword = "7C6A180B36896A0A8C02787EEAFB0E4C";

            Assert.AreNotEqual(realPassword, hashedPassword);
        }
        [TestMethod]
        public void TestMethod7()
        {
            var realPassword = "password1";
            var hashedPassword = DataEncryption.HashingData(realPassword);

            Assert.IsInstanceOfType(hashedPassword, typeof(string));
        }
        [TestMethod]
        public void TestMethod8()
        {
            var realPassword = "password1";
            var hashedPassword = DataEncryption.HashingData(realPassword);

            Assert.IsInstanceOfType(hashedPassword, typeof(string));
        }
        [TestMethod]
        public void TestMethod9()
        {
            var newProductCreationForm = new NewProductCreationForm(new Guid("7569C43C-7D55-4406-97AB-5BFE49DC4658"));

            Assert.IsNotNull(newProductCreationForm, "Форма не должна быть null");
        }
        [TestMethod]
        public void TestMethod10()
        {
            var newProductCreationForm = new NewProductCreationForm(new Guid("7569C43C-7D55-4406-97AB-5BFE49DC4658"));

            Assert.IsInstanceOfType(newProductCreationForm, typeof(NewProductCreationForm));
        }
    }
}