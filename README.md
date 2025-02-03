# CoffeeMachine1
 
![image](https://github.com/user-attachments/assets/a94d2fee-0803-4fc8-bc56-b2afc64d5acd)

using System;
using System.Collections.Generic;

namespace WaterShop
{
    // คลาส Ingredient ใช้เก็บข้อมูลของวัตถุดิบแต่ละชนิด
    internal class Ingredient
    {
        public string Name { get; set; } // ชื่อของวัตถุดิบ
        public int Quantity { get; private set; } // ปริมาณของวัตถุดิบ (อ่านได้แต่แก้ไขโดยตรงไม่ได้)

        // Constructor สำหรับสร้างวัตถุดิบ พร้อมกำหนดชื่อและปริมาณเริ่มต้น
        public Ingredient(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        // เมทอดใช้วัตถุดิบ ลดจำนวนวัตถุดิบตามค่าที่กำหนด
        public bool UseIngredient(int amount)
        {
            if (Quantity >= amount) // เช็คว่ามีวัตถุดิบพอไหม
            {
                Quantity -= amount; // ถ้ามีพอ ให้ลดจำนวนลง
                return true; // ใช้งานสำเร็จ
            }
            return false; // วัตถุดิบไม่พอ ใช้งานไม่สำเร็จ
        }

        // เมทอดเติมวัตถุดิบ เพิ่มจำนวนวัตถุดิบตามค่าที่กำหนด
        public void Refill(int amount)
        {
            Quantity += amount;
        }
    }

    // คลาส CoffeeMachine ใช้สำหรับบริหารจัดการเครื่องทำกาแฟ
    internal class CoffeeMachine
    {
        // Dictionary ใช้เก็บส่วนผสมของเครื่องทำกาแฟ โดยใช้ชื่อเป็น key และ Ingredient เป็น value
        public Dictionary<string, Ingredient> Ingredients { get; private set; }

        // Constructor สร้างเครื่องทำกาแฟ พร้อมกำหนดวัตถุดิบเริ่มต้น
        public CoffeeMachine()
        {
            Ingredients = new Dictionary<string, Ingredient>
            {
                { "Water", new Ingredient("Water", 200) },        // น้ำ เริ่มต้น 200 หน่วย
                { "Coffee", new Ingredient("Coffee", 200) },      // กาแฟ เริ่มต้น 200 หน่วย
                { "Hot_Milk", new Ingredient("Hot Milk", 200) },  // นมร้อน เริ่มต้น 200 หน่วย
                { "Chocolate", new Ingredient("Chocolate", 200) } // ช็อกโกแลต เริ่มต้น 200 หน่วย
            };
        }

        // เมทอดสำหรับทำกาแฟ รับชื่อกาแฟเป็นพารามิเตอร์
        public bool MakeCoffee(string coffeeType)
        {
            Dictionary<string, int> recipe = GetRecipe(coffeeType); // ดึงสูตรของกาแฟชนิดนั้น
            if (recipe == null) return false; // ถ้าไม่มีสูตรของกาแฟชนิดนั้น ให้คืนค่า false

            // ตรวจสอบวัตถุดิบที่ต้องใช้ตามสูตร
            foreach (var item in recipe)
            {
                if (!Ingredients[item.Key].UseIngredient(item.Value)) // ถ้าวัตถุดิบไม่พอ
                {
                    return false; // คืนค่า false ทำกาแฟไม่สำเร็จ
                }
            }
            return true; // ถ้าทุกอย่างผ่านหมด แสดงว่าทำกาแฟสำเร็จ
        }

        // เมทอดสำหรับดึงสูตรกาแฟแต่ละชนิด
        private Dictionary<string, int> GetRecipe(string coffeeType)
        {
            if (coffeeType == "Late") // ถ้ากาแฟเป็นลาเต้
            {
                return new Dictionary<string, int>
                {
                    { "Water", 300 },
                    { "Coffee", 20 }
                };
            }
            else if (coffeeType == "Mocca") // ถ้ากาแฟเป็นมอคค่า
            {
                return new Dictionary<string, int>
                {
                    { "Water", 300 },
                    { "Coffee", 20 },
                    { "Chocolate", 10 }
                };
            }
            else if (coffeeType == "Americano") // ถ้ากาแฟเป็นอเมริกาโน่
            {
                return new Dictionary<string, int>
                {
                    { "Water", 300 },
                    { "Chocolate", 10 }
                };
            }
            else if (coffeeType == "Black") // ถ้ากาแฟเป็นแบล็คคอฟฟี่
            {
                return new Dictionary<string, int>
                {
                    { "Water", 300 },
                    { "Coffee", 20 }
                };
            }
            else
            {
                return null; // ถ้าไม่มีสูตร ให้คืนค่า null
            }
        }
    }
}
