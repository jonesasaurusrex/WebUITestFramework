using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebUITestFramework.PageObjects.Inventory
{
    /// <summary>
    /// Provides methods for interacting with the inventory page
    /// </summary>
    public class InventoryPage : SharedElements
    {
        public const string URL = "https://www.saucedemo.com/inventory.html";
        public const string TITLE = "Swag Labs";
        public static readonly string[] BACKPACK_ELEMENT_IDS = {
            "add-to-cart-sauce-labs-backpack",
            "remove-sauce-labs-backpack",
            "item_4_title_link",
            "item_4_img_link"
        };
        public static readonly string[] BIKE_LIGHT_ELEMENT_IDS = {
            "add-to-cart-sauce-labs-bike-light",
            "remove-sauce-labs-bike-light",
            "item_0_title_link",
            "item_0_img_link"
        };
        public static readonly string[] BOLT_TSHIRT_ELEMENT_IDS = {
            "add-to-cart-sauce-labs-bolt-t-shirt",
            "remove-sauce-labs-bolt-t-shirt",
            "item_1_title_link",
            "item_1_img_link"
        };
        public static readonly string[] FLEECE_JACKET_ELEMENT_IDS = {
            "add-to-cart-sauce-labs-fleece-jacket",
            "remove-sauce-labs-fleece-jacket",
            "item_5_title_link",
            "item_5_img_link"
        };
        public static readonly string[] ONESIE_ELEMENT_IDS = {
            "add-to-cart-sauce-labs-onesie",
            "remove-sauce-labs-onesie",
            "item_2_title_link",
            "item_2_img_link"
        };
        public static readonly string[] TEST_ALL_THE_THINGS_TSHIRT_ELEMENT_IDS = {
            "add-to-cart-test.allthethings()-t-shirt-(red)",
            "remove-test.allthethings()-t-shirt-(red)",
            "item_3_title_link",
            "item_3_img_link"
        };

        private IWebDriver _driver;

        public InventoryItemSection BackpackSection { get; set; }

        public InventoryItemSection BikeLightSection { get; set; }

        public InventoryItemSection BoltTShirtSection { get; set; }

        public InventoryItemSection FleeceJacketSection { get; set; }

        public InventoryItemSection OnesieSection { get; set; }

        public InventoryItemSection TestAllTheThingsTShirtSection { get; set; }


        public InventoryPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            PageFactory.InitElements(driver, this);

            BackpackSection = new InventoryItemSection(
                driver,
                BACKPACK_ELEMENT_IDS[0],
                BACKPACK_ELEMENT_IDS[1],
                BACKPACK_ELEMENT_IDS[2],
                BACKPACK_ELEMENT_IDS[3]
                );


            BikeLightSection = new InventoryItemSection(
                driver,
                BIKE_LIGHT_ELEMENT_IDS[0],
                BIKE_LIGHT_ELEMENT_IDS[1],
                BIKE_LIGHT_ELEMENT_IDS[2],
                BIKE_LIGHT_ELEMENT_IDS[3]
                );

            BoltTShirtSection = new InventoryItemSection(
                driver,
                BOLT_TSHIRT_ELEMENT_IDS[0],
                BOLT_TSHIRT_ELEMENT_IDS[1],
                BOLT_TSHIRT_ELEMENT_IDS[2],
                BOLT_TSHIRT_ELEMENT_IDS[3]
                );

            FleeceJacketSection = new InventoryItemSection(
                driver,
                FLEECE_JACKET_ELEMENT_IDS[0],
                FLEECE_JACKET_ELEMENT_IDS[1],
                FLEECE_JACKET_ELEMENT_IDS[2],
                FLEECE_JACKET_ELEMENT_IDS[3]
                );

            OnesieSection = new InventoryItemSection(
                driver,
                ONESIE_ELEMENT_IDS[0],
                ONESIE_ELEMENT_IDS[1],
                ONESIE_ELEMENT_IDS[2],
                ONESIE_ELEMENT_IDS[3]
                );

            TestAllTheThingsTShirtSection = new InventoryItemSection(
                driver,
                TEST_ALL_THE_THINGS_TSHIRT_ELEMENT_IDS[0],
                TEST_ALL_THE_THINGS_TSHIRT_ELEMENT_IDS[1],
                TEST_ALL_THE_THINGS_TSHIRT_ELEMENT_IDS[2],
                TEST_ALL_THE_THINGS_TSHIRT_ELEMENT_IDS[3]
                );
        }
    }
}