// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.



using System.Windows.Controls;
using System.Collections.Generic;



namespace PathAnimations
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
        }
        /*
        *Created completely by Yusuf Sami Kaygusuz.
        *All right reserved.
        */



        // Type of Shapes
        public enum typeOfShapes
        {
            quadrilateral, // Dörtgen
            square, // Kare
            triangle, // Üçgen
            rectangle, //dikdörtgen
            equilateral_Triangle, // Eþkenar Üçgen
            issosceles_Triangle, // Ýkizkenar Üçgen
            trapezoid // Yamuk
        }
        //Component
        public abstract class shapes
        {
            protected string _name;
            protected typeOfShapes _typeOfShapes;



            protected shapes(string name, typeOfShapes typeOfShapes)
            {
                _name = name;
                _typeOfShapes = typeOfShapes;
            }



            public abstract void AddShapes(shapes _shapes);
            public abstract void RemoveShapes(shapes _shapes);



        }



        //composite
        public class secondGeneration : shapes
        {
            List<shapes> shapes = new List<shapes>();



            public secondGeneration(string name, typeOfShapes typeOfShapes) : base(name, typeOfShapes)
            {



            }



            public override void AddShapes(shapes _shapes)
            {
                shapes.Add(_shapes);
            }



            public override void RemoveShapes(shapes _shapes)
            {
                shapes.Remove(_shapes);
            }



        }



        //leaf
        public class ThirdGeneration : shapes
        {
            public ThirdGeneration(string name, typeOfShapes typeOfShapes) : base(name, typeOfShapes)
            {



            }



            public override void AddShapes(shapes _shapes)
            {
                throw new System.NotImplementedException();
            }



            public override void RemoveShapes(shapes _shapes)
            {
                throw new System.NotImplementedException();
            }
        }




        public void GeneralFunction()
        {
            //Composite nesnesi oluþturdu.
            secondGeneration LsecondGeneration_ = new secondGeneration("Dörtgen", typeOfShapes.quadrilateral);
            //Oluþturulan ilk composite nesnesinin Leaf nesneleri oluþtruldu.
            LsecondGeneration_.AddShapes(new ThirdGeneration("Kare", typeOfShapes.square));
            LsecondGeneration_.AddShapes(new ThirdGeneration("Dikdörtgen", typeOfShapes.rectangle));
            LsecondGeneration_.AddShapes(new ThirdGeneration("Yamuk", typeOfShapes.trapezoid));




            //Ýkinci Composite nesnesi oluþturdu.
            secondGeneration RsecondGeneration_ = new secondGeneration("Üçgen", typeOfShapes.triangle);
            //Oluþturulan ikinci composite nesnesinin Leaf nesneleri oluþtruldu.
            RsecondGeneration_.AddShapes(new ThirdGeneration("Eþkenar Üçgen", typeOfShapes.equilateral_Triangle));
            RsecondGeneration_.AddShapes(new ThirdGeneration("Ýkizkenar Üçgen", typeOfShapes.issosceles_Triangle));



        }
    }
}