using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Logica;
using System;
using System.Threading;

namespace Chess
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private string movimiento;
        private bool seleccionadoCuadrado;
        private bool seleccionadaPieza;
        private bool moverPieza;
        private bool movimientoCorrecto;
        private bool piezaMoviada;
        private bool turnoLocal;
        private bool seleccionadoCuadroRemoto;
        private bool seleccionadaPiezaRemota;
        private bool abandono;

        private int ladoCuadrado;
        private Vector2[,] posiciones = new Vector2[8,8];
        private Vector2 posicionTablero;
        private Vector2 posicionTexto;
        private string texto;

        private Texture2D board;
        private Texture2D cuadradoBlanco;
        private Texture2D cuadradoNegro;
        private Texture2D peonBlanco;
        private Texture2D peonNegro;
        private Texture2D torreBlanca;
        private Texture2D torreNegra;
        private Texture2D caballoBlanco;
        private Texture2D caballoNegro;
        private Texture2D afilBlanco;
        private Texture2D afilNegro;
        private Texture2D reyBlanco;
        private Texture2D reyNegro;
        private Texture2D damaBlanca;
        private Texture2D damaNegra;
        private SpriteFont fuente;

        private long tiempo;
        private long tiempoMovimiento;
        private long tiempoSemaforo;
        private long tiempoRemoto;

        private Juego juego;

        private int[] cuadroSelect = new int[2];
        private int[] piezaSelect = new int[2];

        private Thread hiloTurno;
        private static readonly object l = new object();

        public Game1(Juego juego)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "SuperChess Online";
            posicionTablero = new Vector2();
            posicionTexto = new Vector2();
            IsMouseVisible = true;
            seleccionadoCuadrado = false;
            seleccionadaPieza = false;
            moverPieza = false;
            piezaMoviada = false;
            this.juego = juego;
            hiloTurno = new Thread(realizarTurno);
        }

        protected override void Initialize()
        {
            base.Initialize();
            juego.iniciarJuego();
            turnoLocal = juego.JugadorLocal.Blanco;
            abandono = false;
            tiempo = DateTime.Now.Ticks;
            tiempoMovimiento = DateTime.Now.Ticks;
            tiempoRemoto = DateTime.Now.Ticks;
            hiloTurno.Start();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            board = this.Content.Load<Texture2D>("board");
            cuadradoNegro = this.Content.Load<Texture2D>("squareB");
            cuadradoBlanco = this.Content.Load<Texture2D>("squareW");
            peonBlanco = this.Content.Load<Texture2D>("pawnW2");
            peonNegro = this.Content.Load<Texture2D>("pawnB2");
            torreBlanca = this.Content.Load<Texture2D>("rookW2");
            torreNegra = this.Content.Load<Texture2D>("rookB2");
            caballoBlanco = this.Content.Load<Texture2D>("knightW2");
            caballoNegro = this.Content.Load<Texture2D>("knightB2");
            afilBlanco = this.Content.Load<Texture2D>("bishopW2");
            afilNegro = this.Content.Load<Texture2D>("bishopB2");
            reyBlanco = this.Content.Load<Texture2D>("kingW2");
            reyNegro = this.Content.Load<Texture2D>("kingB2");
            damaBlanca = this.Content.Load<Texture2D>("queenW2");
            damaNegra = this.Content.Load<Texture2D>("queenB2");
            fuente = this.Content.Load<SpriteFont>("Font");
            texto = "Abandono del rival de la partida";
            posicionTexto.X = this.Window.ClientBounds.Width / 2 - fuente.MeasureString(texto).X/2;
            posicionTexto.Y =  this.Window.ClientBounds.Height / 2 - fuente.MeasureString(texto).Y/2;
            int margin = board.Height / 32;
            ladoCuadrado = (board.Height - margin - margin / 2) / 8;
            posicionTablero.X = this.Window.ClientBounds.Width/2 - board.Width / 2;
            posicionTablero.Y = this.Window.ClientBounds.Height/2 - board.Height / 2;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posiciones[i,j] = new Vector2(posicionTablero.X +margin + i * ladoCuadrado, 
                        posicionTablero.Y + margin + (7 - j) * ladoCuadrado);
                }
            }
        }

        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!juego.Tablero.EndGame)
            {
                moverPiezaTablero();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            dibujarTablero();
            if (abandono) spriteBatch.DrawString(fuente, texto, posicionTexto, Color.DarkRed);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void  OnExiting(object sender, EventArgs args)
        {
            juego.Tablero.EndGame = true;
            juego.enviarMovimiento(null);
            juego.cerrarConexion();
            base.OnExiting(sender, args);
        }

        private void realizarTurno()
        {
            do
            {
                if (!turnoLocal)
                {
                    movimiento = juego.recibirMovimiento();
                    Console.WriteLine("MOVIMIENTO RECIBIR mod{0}", movimiento);
                    //Console.WriteLine("MOVIMIENTO RECIBIR lengt {0}", movimiento.Length);
                    if (movimiento != null && movimiento != "") {
                        juego.Tablero.moverRemoto(movimiento);
                        señalarMovimientoRemoto(movimiento);
                        turnoLocal = true;
                    }
                    else
                    {
                        abandono = true;
                    }
                }
                else
                {
                    lock (l) {
                        Monitor.Wait(l);

                        juego.enviarMovimiento(movimiento);
                        turnoLocal = false;
                    }

                };
            } while (!juego.Tablero.EndGame && movimiento != null && movimiento != "");
            juego.Tablero.EndGame = true;

            Console.WriteLine("EndGame: {0}", juego.Tablero.EndGame);
        }

        private void señalarMovimientoRemoto(string movimiento)
        {
            piezaSelect[0] = Convert.ToChar(movimiento.Substring(3, 1)) - 'A';
            piezaSelect[1] = Convert.ToInt32(movimiento.Substring(4, 1)) - 1;
            seleccionadaPiezaRemota = true;
            cuadroSelect[0] = Convert.ToChar(movimiento.Substring(1, 1)) - 'A';
            cuadroSelect[1] = Convert.ToInt32(movimiento.Substring(2, 1)) - 1;
            seleccionadoCuadroRemoto = true;
            tiempoRemoto = DateTime.Now.Ticks;
        }

        private void dibujarTablero()
        {
            spriteBatch.Draw(board, posicionTablero, Color.White);
            int cont = 0;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++)
                {
                    cont++;
                    Color color = Color.White;
                    if (seleccionadoCuadrado) {
                        if (cuadroSelect[0] == i && cuadroSelect[1] == j)
                        {
                            color = Color.Yellow;
                            if(piezaMoviada)
                            {
                                if (movimientoCorrecto)
                                {
                                    color = Color.Green;
                                }
                                else
                                {
                                    color = Color.Red;
                                }
                            }
                        }
                    }
                    if (seleccionadoCuadroRemoto)
                    {
                        if (cuadroSelect[0] == i && cuadroSelect[1] == j)
                        {
                            color = Color.Yellow;
                        }
                    }
                    if (cont % 2 != 0)
                    {
                        spriteBatch.Draw(cuadradoBlanco, posiciones[i,j], color); 
                    }
                    else
                    {
                        spriteBatch.Draw(cuadradoNegro, posiciones[i,j], color);
                    }
                    colocarPiezas(i, j);
                }
                cont++;
            }

        }

        private void colocarPiezas(int i, int j)
        {
            Texture2D imagenPieza = null;
            switch (juego.Tablero.TableroPiezas[i,j])
            {
                case 'P':
                    imagenPieza = peonBlanco;
                    break;
                case 'p':
                    imagenPieza = peonNegro;
                    break;
                case 'T':
                    imagenPieza = torreBlanca;
                    break;
                case 't':
                    imagenPieza = torreNegra;
                    break;
                case 'C':
                    imagenPieza = caballoBlanco;
                    break;
                case 'c':
                    imagenPieza = caballoNegro;
                    break;
                case 'A':
                    imagenPieza = afilBlanco;
                    break;
                case 'a':
                    imagenPieza = afilNegro;
                    break;
                case 'R':
                    imagenPieza = reyBlanco;
                    break;
                case 'r':
                    imagenPieza = reyNegro;
                    break;
                case 'D':
                    imagenPieza = damaBlanca;
                    break;
                case 'd':
                    imagenPieza = damaNegra;
                    break;
            }
            if (imagenPieza != null)
            {
                Color color = Color.White;
                if (seleccionadaPieza)
                {
                    if (i == piezaSelect[0] && j == piezaSelect[1])
                    {
                        if(juego.JugadorLocal.Blanco)color = Color.Yellow;
                        else color = Color.Red;
                    }
                }
                if (seleccionadaPiezaRemota)
                {
                    if (i == piezaSelect[0] && j == piezaSelect[1])
                    {
                        if (!juego.JugadorLocal.Blanco) color = Color.Yellow;
                        else color = Color.Red;
                    }
                }
                spriteBatch.Draw(imagenPieza, posiciones[i, j], color);
            }
        }

        private void moverPiezaTablero()
        {
            MouseState mouseState = Mouse.GetState();
            if (DateTime.Now.Ticks - tiempo > TimeSpan.TicksPerSecond / 3)
            {
                if (ButtonState.Pressed == mouseState.LeftButton && turnoLocal)
                {
                    seleccionarRaton(mouseState.Position);
                    tiempo = DateTime.Now.Ticks;
                }

            }


            if (moverPieza)
            {
                if (DateTime.Now.Ticks - tiempoMovimiento > TimeSpan.TicksPerSecond / 3
                    && movimiento != null && movimiento != "")
                {

                    movimientoCorrecto = juego.Tablero.mover(movimiento, juego.JugadorLocal.Blanco);

                    if (movimientoCorrecto)
                    {
                        lock (l)
                        {
                            Monitor.Pulse(l);
                        }
                    }
                    moverPieza = false;
                    piezaMoviada = true;
                    tiempoSemaforo = DateTime.Now.Ticks;
                }
            }

            if (piezaMoviada)
            {
                if (DateTime.Now.Ticks - tiempoSemaforo > TimeSpan.TicksPerSecond / 3)
                {
                    seleccionadoCuadrado = false;
                    seleccionadaPieza = false;
                    piezaMoviada = false;
                }
            }

            if (seleccionadaPiezaRemota)
            {
                if (DateTime.Now.Ticks - tiempoRemoto > TimeSpan.TicksPerSecond)
                {
                    seleccionadoCuadroRemoto = false;
                    seleccionadaPiezaRemota = false;
                }
            }
        }

        private void seleccionarRaton(Point posicionRaton)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x = (int)posiciones[i, j].X;
                    int y = (int)posiciones[i, j].Y;
                    if (posicionRaton.X >= x && posicionRaton.X <= x + ladoCuadrado &&
                        posicionRaton.Y >= y && posicionRaton.Y <= y + ladoCuadrado)
                    {
                        if (seleccionadaPieza)
                        {
                            if (piezaSelect[0] == i && piezaSelect[1] == j)
                            {
                                seleccionadaPieza = false;
                                seleccionadoCuadrado = false;
                            }
                            else
                            {
                                cuadroSelect[0] = i;
                                cuadroSelect[1] = j;
                                seleccionadoCuadrado = true;
                                movimiento = string.Format("{0}{1}{2}",
                                    movimiento,
                                    (char)('A'+i),
                                    j+1);
                                moverPieza = true;
                                tiempoMovimiento = DateTime.Now.Ticks;
                            }
                        }
                        else
                        {
                            if (juego.Tablero.TableroPiezas[i, j] != null) {
                                if ((juego.JugadorLocal.Blanco && juego.Tablero.TableroPiezas[i, j] < 'Z') ||
                                    (!juego.JugadorLocal.Blanco && juego.Tablero.TableroPiezas[i, j] > 'Z')) {
                                    piezaSelect[0] = i;
                                    piezaSelect[1] = j;
                                    seleccionadaPieza = true;
                                    movimiento = string.Format("{0}{1}{2}",
                                            juego.Tablero.TableroPiezas[i, j],
                                            (char)('A' + i),
                                            j + 1);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
