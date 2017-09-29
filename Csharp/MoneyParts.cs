using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    public class MoneyParts
    {

        public List<List<String>> build(String Monto)
        {
            List<List<String>> res = new List<List<String>>();
            Double DvMonto = Convert.ToDouble(decimal.Parse(Monto, System.Globalization.CultureInfo.InvariantCulture));
            List<Double> LsDenomina = new List<Double>();
            LsDenomina.Add(0.05);
            LsDenomina.Add(0.1);
            LsDenomina.Add(0.2);
            LsDenomina.Add(0.5);
            LsDenomina.Add(1);
            LsDenomina.Add(2);
            LsDenomina.Add(5);
            LsDenomina.Add(10);
            LsDenomina.Add(20);
            LsDenomina.Add(50);
            LsDenomina.Add(100);
            LsDenomina.Add(200);

            for (int i = 0; i < LsDenomina.Count; i++)
            {
                if ((Convert.ToInt32(DvMonto % LsDenomina[i]) == 0) && (DvMonto > LsDenomina[i]))
                {
                    List<String> LsCombinacion = new List<String>(); 
                    for (int ix = 0; ix < (DvMonto / LsDenomina[i]); ix++)
                    {
                        LsCombinacion.Add(LsDenomina[i].ToString());
                    }
                    res.Add(LsCombinacion);                    
                }
                if (DvMonto == LsDenomina[i])
                {
                    List<String> LsIgual = new List<String>();
                    LsIgual.Add(LsDenomina[i].ToString());
                    res.Add(LsIgual);
                }
            }            
            return res;
        }
    }
}
