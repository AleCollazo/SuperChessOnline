using Logica;
using System;
using System.Windows.Forms;

namespace Chess
{
#if WINDOWS || LINUX

    public static class Program
    {
        public static bool conexionCorrecta = false;

        [STAThread]
        static void Main()
        {
            Juego juego = new Juego();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(juego));

            if (conexionCorrecta)
            {
                using (var game = new Game1(juego))
                    game.Run();
            }
        }
    }
#endif
}
