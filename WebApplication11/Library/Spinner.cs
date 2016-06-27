﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHunspell;

namespace WebApplication11.Library
{
    public class Spinner
    {
        public static string SpinText(string text)
        {
            var words = text.Split(' ');

            
            MyThes thes = new MyThes("th_en_US_new.dat");
            Hunspell hunspell = new Hunspell("en_US.aff", "en_US.dic");
            for (var i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                ThesResult tr = thes.Lookup(words[i], hunspell);
                if (tr != null)
                {
                    foreach (ThesMeaning meaning in tr.Meanings)
                    {
                        foreach (string synonym in meaning.Synonyms)
                        {
                            
                            sb.Append(synonym + "|");
                        }
                    }
                }
                if(sb.ToString().Length > 2)
                    words[i] = "{" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "}";
            }
            text = string.Join(" ", words);
            return text;
        }

        public static string GetSpunText(string text)
        {
            var words = text.Split(' ');


            MyThes thes = new MyThes("th_en_US_new.dat");
            Hunspell hunspell = new Hunspell("en_US.aff", "en_US.dic");
            for (var i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                ThesResult tr = thes.Lookup(words[i], hunspell);
                if (tr != null)
                {
                    foreach (ThesMeaning meaning in tr.Meanings)
                    {
                        Random random = new Random();
                        
                        words[i] = meaning.Synonyms[random.Next(0, meaning.Synonyms.Count())];
                    }
                }
            }
            text = string.Join(" ", words);
            return text;
        }

        public static string GetLightSpunText(string text)
        {
            var words = text.Split(' ');


            MyThes thes = new MyThes("th_en_US_new.dat");
            Hunspell hunspell = new Hunspell("en_US.aff", "en_US.dic");
            for (var i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                ThesResult tr = thes.Lookup(words[i], hunspell);
                if (tr != null)
                {
                    foreach (ThesMeaning meaning in tr.Meanings)
                    {
                        Random random = new Random();

                        words[i] = meaning.Synonyms[0];
                    }
                }
            }
            text = string.Join(" ", words);
            return text;
        }
    }
}