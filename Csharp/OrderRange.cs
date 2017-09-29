using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    public class OrderRange
    {

        private List<int> vArryPar = new List<int>();
        private List<int> vArryImpar = new List<int>();

        public List<int> ArryPar
        {
            get
            {
                return vArryPar;
            }
            set
            {
                vArryPar = value;
            }
        }
        
        public List<int> ArryImpar
        {
            get
            {
                return vArryImpar;
            }
            set
            {
                vArryImpar = value;
            }
        }

        public List<int>[] build(int[] numeros)
        {
            List<int>[] resultado = new List<int>[2];
            List<int> vrArryPar = new List<int>();
            List<int> vrArryImpar = new List<int>();


            for (int i = 0; i < numeros.Length; i++)
            {
                if((numeros[i] % 2) == 0)
                {
                    vrArryPar.Add(numeros[i]);
                }
                else
                {
                    vrArryImpar.Add(numeros[i]);
                }
            }
            vrArryPar.Sort();
            vrArryImpar.Sort();
            resultado[0] = vrArryPar;
            resultado[1] = vrArryImpar;

            return resultado;
        }        

    }

}
