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
            quadrilateral, // D�rtgen
            square, // Kare
            triangle, // ��gen
            rectangle, //dikd�rtgen
            equilateral_Triangle, // E�kenar ��gen
            issosceles_Triangle, // �kizkenar ��gen
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
            //Composite nesnesi olu�turdu.
            secondGeneration LsecondGeneration_ = new secondGeneration("D�rtgen", typeOfShapes.quadrilateral);
            //Olu�turulan ilk composite nesnesinin Leaf nesneleri olu�truldu.
            LsecondGeneration_.AddShapes(new ThirdGeneration("Kare", typeOfShapes.square));
            LsecondGeneration_.AddShapes(new ThirdGeneration("Dikd�rtgen", typeOfShapes.rectangle));
            LsecondGeneration_.AddShapes(new ThirdGeneration("Yamuk", typeOfShapes.trapezoid));




            //�kinci Composite nesnesi olu�turdu.
            secondGeneration RsecondGeneration_ = new secondGeneration("��gen", typeOfShapes.triangle);
            //Olu�turulan ikinci composite nesnesinin Leaf nesneleri olu�truldu.
            RsecondGeneration_.AddShapes(new ThirdGeneration("E�kenar ��gen", typeOfShapes.equilateral_Triangle));
            RsecondGeneration_.AddShapes(new ThirdGeneration("�kizkenar ��gen", typeOfShapes.issosceles_Triangle));



        }
    }
}