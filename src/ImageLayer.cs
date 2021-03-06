// Distributed as part of TiledSharp, Copyright 2012 Marshall Ward
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0
using System;
using System.Xml.Linq;

namespace TiledSharp
{
    public class TmxImageLayer : ITmxElement
    {
        public string Name {get; private set;}
        public int Width {get; private set;}
        public int Height {get; private set;}

        public bool Visible {get; private set;}
        public double Opacity {get; private set;}

        public TmxImage Image {get; private set;}
 
        public PropertyDict Properties {get; private set;}

        public TmxImageLayer(XElement xImageLayer)
        {
            Name = (string)xImageLayer.Attribute("name");
            Width = (int)xImageLayer.Attribute("width");
            Height = (int)xImageLayer.Attribute("height");

            var xVisible = xImageLayer.Attribute("visible");
            if (xVisible == null)
                Visible = true;
            else
                Visible = (bool)xVisible;

            var xOpacity = xImageLayer.Attribute("opacity");
            if (xOpacity == null)
                Opacity = 1.0;
            else
                Opacity = (double)xOpacity;

            Image = new TmxImage(xImageLayer.Element("image"));
            
            Properties = new PropertyDict(xImageLayer.Element("properties"));
        }
    }
}
