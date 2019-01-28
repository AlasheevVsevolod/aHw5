using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advenced.Lesson_4
{
    public partial class Practice
    {
        /// <summary>
        /// AL4-P1/5.InstanceCounter. 
        /// AL4-P2/5.InstanceCounterWithHeapSize.
        /// AL4-P3/5.InstanceCounterWithGCCollect.
        /// </summary>
        public static void AL4_P1_P2_P3_5_InstanceCounter()
        {
            for (int i = 0; i < 5000000; i++)
            {
                using (var newCntr = new CntrClass())
                {
                    if ((i % 50000) == 0)
                    {
                        Console.WriteLine($"{CntrClass.cntr}\t{System.GC.GetTotalMemory(false)}");
                        System.GC.Collect();
                        Console.WriteLine($"{CntrClass.cntr}\t{System.GC.GetTotalMemory(false)}");
                    }
                    //newCntr.Dispose();
                }
            }
        }

        public class CntrClass  : IDisposable
        {
            public static int cntr;

            public CntrClass()
            {
                cntr++;
            }

            public void Dispose()
            {
                cntr--;
                System.GC.SuppressFinalize(this);
//                Console.WriteLine("Explicit disposing");
            }

            ~CntrClass()
            {
//                Console.WriteLine("Implicit disposing");
            }
        }

        /// <summary>
        /// AL4-P4/5. IDisposable. 
        /// AL4-P4/5. IDisposableWithSuppress. 
        /// </summary>
        public static void AL4_P4_P5_5_InstanceCounter()
        {
        }
    }
}
