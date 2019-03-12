using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softech.Utility
{
    public class Utility
    {
        public static IEnumerable<SelectListItem> GetGenderList()
        {
            return new SelectList(new[]
            {
                new{Id="Male", Value="Male"},
                 new{Id="Female", Value="Female"},
            }, "Id", "Value");
        }
        public static string Convert(int number)
        {
            var afterconvert = " ";
            if ((number / 1000000000) > 0)
            {
                afterconvert += Convert(number / 1000000000) + "अर्ब ";
                number = number % 1000000000;
            }
            if ((number / 10000000) > 0)
            {
                afterconvert += Convert(number / 10000000) + "करोड ";
                number = number % 10000000;
            }
            if ((number / 100000) > 0)
            {
                afterconvert += Convert(number / 100000) + "लाख ";
                number = number % 100000;
            }


            if ((number / 1000) > 0)
            {
                afterconvert += Convert(number / 1000) + "हजार ";
                number = number % 1000;
            }
            if ((number / 100) > 0)
            {
                afterconvert += Convert(number / 100) + "सय ";
                number = number % 100;
            }
            if (number < 0)
            {
                afterconvert += "-";
                number = number * (-1);

            }

            if (number <= 100 && number > 0)
            {
                var words = new string[] { "शुन्य", "एक", "दुई", "तीन", "चार", "पाँच", "छ", "सात", "आठ", "नौ", "दश", "एघार","बाह्र","तेह्र","चौध","पन्ध्र","सोह्र","सत्र",
                                        "अठार","उन्नाइस","विस","एक्काइस","बाइस","तेईस","चौविस","पच्चिस","छब्बिस","सत्ताइस","अठ्ठाईस","उनन्तिस","तिस","एकत्तिस","बत्तिस","तेत्तिस","चौँतिस","पैँतिस","छत्तिस","सैँतीस","अठतीस","उनन्चालीस","चालीस",
                                        "एकचालीस","बयालीस","त्रियालीस","चवालीस","पैँतालीस","छयालीस","सच्चालीस","अठचालीस","उनन्चास","पचास","एकाउन्न","बाउन्न","त्रिपन्न","चउन्न","पचपन्न","छपन्न","सन्ताउन्न","अन्ठाउन्न","उनन्साठी","साठी","एकसट्ठी","बयसट्ठी","त्रिसट्ठी","चौंसट्ठी","पैंसट्ठी","छयसट्ठी","सतसट्ठी","अठसट्ठी","उनन्सत्तरी","सत्तरी","एकहत्तर","बहत्तर","त्रिहत्तर","चौहत्तर","पचहत्तर","छयहत्तर","सतहत्तर","अठहत्तर","उनासी","असी","एकासी","बयासी","त्रियासी","चौरासी","पचासी","छयासी","सतासी","अठासी","उनान्नब्बे","नब्बे","एकान्नब्बे","बयानब्बे","त्रियान्नब्बे","चौरान्नब्बे","पन्चानब्बे","छयान्नब्बे","सन्तान्नब्बे","अन्ठान्नब्बे","उनान्सय"};
                afterconvert += words[number];

            }
            return afterconvert;
        }
    }
}

