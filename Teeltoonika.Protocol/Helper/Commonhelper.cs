using System;

namespace Teeltoonika.Protocol.Helper
{
    public static class Commonhelper
    {
        public static bool IsValidImei(string imei)
        {
            try
            {
                int[] n = new int[imei.Length];
                for (int i = 0; i < imei.Length; i++)
                {
                    n[i] = int.Parse(imei[i].ToString());
                }

                for (int i = 0; i < imei.Length - 1; i++)
                {
                    if (i % 2 == 1)
                    {
                        n[i] = n[i] * 2;
                    }
                }

                for (int i = 0; i < imei.Length - 1; i++)
                {
                    if (i % 2 == 1)
                    {
                        if (n[i].ToString().Length > 1)
                            n[i] = int.Parse(n[i].ToString()[0].ToString()) + int.Parse(n[i].ToString()[1].ToString());
                    }
                }

                int total = 0;
                for (int i = 0; i < imei.Length - 1; i++)
                {
                    total += n[i];
                }

                int mod = total % 10;

                if (mod > 0)
                {
                    mod = 10 - mod;
                }

                return (n[imei.Length - 1] == mod);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return false;
            }
        }

    }

}
