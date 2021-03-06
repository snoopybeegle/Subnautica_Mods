﻿using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace BetterSeaglide.Menus
{
    public static class Config
    {
        public static SerializableColor FlashLightColor = new Color(0.016f, 1.0f, 1.0f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float seagliderValue;
        public static float seaglidegValue;
        public static float seaglidebValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static float spotAngle;
        public static bool SeaGlideColor;

        //dev
        public static float x;
        public static float y;
        public static float z;
        public static float w;
        public static float x1;
        public static float y1;
        public static float z1;

        public static void Load()
        {
            rValue = PlayerPrefs.GetFloat("R", 0.016f);
            gValue = PlayerPrefs.GetFloat("G", 1.000f);
            bValue = PlayerPrefs.GetFloat("B", 1.000f);
            seagliderValue = PlayerPrefs.GetFloat("SeaglideR", 0.016f);
            seaglidegValue = PlayerPrefs.GetFloat("SeaglideG", 1.000f);
            seaglidebValue = PlayerPrefs.GetFloat("SeaglideB", 1.000f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 0.9f);
            Range = PlayerPrefs.GetFloat("Range", 40f);
            spotAngle = PlayerPrefs.GetFloat("Size", 70f);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
            SeaGlideColor = PlayerPrefsExtra.GetBool("SeaGlideColor", false);

            //dev 344.5f, 5.7f, 357.1f
            x = PlayerPrefs.GetFloat("X", -0.6f);
            y = PlayerPrefs.GetFloat("Y", 0.6f);
            z = PlayerPrefs.GetFloat("Z", 0.4f);
            w = PlayerPrefs.GetFloat("W", 0.4f);

            x1 = PlayerPrefs.GetFloat("X1", 0.0f);
            y1 = PlayerPrefs.GetFloat("Y1", 0.0f);
            z1 = PlayerPrefs.GetFloat("Z1", 0.0f);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("BetterSeaglide Settings and Lights")
        {
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
            { 
            if (e.Id == "toggleColor")
            {
                Config.ToggleColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleColor", e.Value);
            }
            else if (e.Id == "seaglidecolor")
            {
                Config.SeaGlideColor = e.Value;
                PlayerPrefsExtra.SetBool("SeaGlideColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "r")
            {
                Config.rValue = e.Value;
                PlayerPrefs.SetFloat("R", e.Value);
            }
            else if (e.Id == "g")
            {
                Config.gValue = e.Value;
                PlayerPrefs.SetFloat("G", e.Value);
            }
            else if (e.Id == "b")
            {
                Config.bValue = e.Value;
                PlayerPrefs.SetFloat("B", e.Value);
            }
            else if (e.Id == "intensity")
            {
                Config.Intensity = e.Value;
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }
            else if (e.Id == "range")
            {
                Config.Range = e.Value;
                PlayerPrefs.SetFloat("Range", e.Value);
            }
            else if (e.Id == "size")
            {
                Config.spotAngle = e.Value;
                PlayerPrefs.SetFloat("Size", e.Value);
            }
            else if (e.Id == "seaglider")
            {
                Config.seagliderValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideR", e.Value);
            }
            else if (e.Id == "seaglideg")
            {
                Config.seaglidegValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideG", e.Value);
            }
            else if (e.Id == "seaglideb")
            {
                Config.seaglidebValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideB", e.Value);
            }
            //dev
            else if (e.Id == "x")
            {
                Config.x = e.Value;
                PlayerPrefs.SetFloat("X", e.Value);
            }
            else if (e.Id == "y")
            {
                Config.y = e.Value;
                PlayerPrefs.SetFloat("Y", e.Value);
            }
            else if (e.Id == "z")
            {
                Config.z = e.Value;
                PlayerPrefs.SetFloat("Z", e.Value);
            }
            else if (e.Id == "w")
            {
                Config.w = e.Value;
                PlayerPrefs.SetFloat("W", e.Value);
            }
            else if (e.Id == "x1")
            {
                Config.x1 = e.Value;
                PlayerPrefs.SetFloat("X1", e.Value);
            }
            else if (e.Id == "y1")
            {
                Config.y1 = e.Value;
                PlayerPrefs.SetFloat("Y1", e.Value);
            }
            else if (e.Id == "z1")
            {
                Config.z1 = e.Value;
                PlayerPrefs.SetFloat("Z1", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            if (Config.ToggleColor && Config.SeaGlideColor == false)
            {
                AddToggleOption("toggleColor", "Show BetterSeaglide Light RGB Sliders", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                //dev
                AddSliderOption("x", "X", -999.0f, 999.0f, Config.x);
                AddSliderOption("y", "Y", -999.0f, 999.0f, Config.y);
                AddSliderOption("z", "z", -999.0f, 999.0f, Config.z);
                AddSliderOption("w", "W", -999.0f, 999.0f, Config.w);

                AddSliderOption("x1", "X1", -1.0f, 1.0f, Config.x1);
                AddSliderOption("y1", "Y1", -1.0f, 1.0f, Config.y1);
                AddSliderOption("z1", "Z1", -1.0f, 1.0f, Config.z1);
                Config.Load();
            }
            else if(Config.SeaGlideColor && Config.ToggleColor == false)
            {
                AddToggleOption("toggleColor", "Show BetterSeaglide Light RGB Sliders", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, Config.seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, Config.seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, Config.seaglidebValue);
                //dev
                AddSliderOption("x", "X", -999.0f, 999.0f, Config.x);
                AddSliderOption("y", "Y", -999.0f, 999.0f, Config.y);
                AddSliderOption("z", "z", -999.0f, 999.0f, Config.z);
                AddSliderOption("w", "W", -999.0f, 999.0f, Config.w);

                AddSliderOption("x1", "X1", -999.0f, 999.0f, Config.x1);
                AddSliderOption("y1", "Y1", -999.0f, 999.0f, Config.y1);
                AddSliderOption("z1", "Z1", -999.0f, 999.0f, Config.z1);
                Config.Load();
            }
            else if(Config.ToggleColor && Config.SeaGlideColor)
            {
                AddToggleOption("toggleColor", "Show BetterSeaglide Light RGB Sliders", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, Config.seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, Config.seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, Config.seaglidebValue);
                //dev
                AddSliderOption("x", "X", -999.0f, 999.0f, Config.x);
                AddSliderOption("y", "Y", -999.0f, 999.0f, Config.y);
                AddSliderOption("z", "z", -999.0f, 999.0f, Config.z);
                AddSliderOption("w", "W", -999.0f, 999.0f, Config.w);

                AddSliderOption("x1", "X1", -999.0f, 999.0f, Config.x1);
                AddSliderOption("y1", "Y1", -999.0f, 999.0f, Config.y1);
                AddSliderOption("z1", "Z1", -999.0f, 999.0f, Config.z1);
                Config.Load();
            }
            else
            {
                AddToggleOption("toggleColor", "Show BetterSeaglide Light RGB Sliders", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                //dev
                AddSliderOption("x", "X", -999.0f, 999.0f, Config.x);
                AddSliderOption("y", "Y", -999.0f, 999.0f, Config.y);
                AddSliderOption("z", "z", -999.0f, 999.0f, Config.z);
                AddSliderOption("w", "W", -999.0f, 999.0f, Config.w);

                AddSliderOption("x1", "X1", -999.0f, 999.0f, Config.x1);
                AddSliderOption("y1", "Y1", -999.0f, 999.0f, Config.y1);
                AddSliderOption("z1", "Z1", -999.0f, 999.0f, Config.z1);
                Config.Load();
            }
        }
    }
}