using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Logica;
using System;

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

        private int ladoCuadrado;
        private Vector2[,] posiciones = new Vector2[8,8];

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

        private long tiempo;
        private long tiempoMovimiento;
        private long tiempoSemaforo;

        private Juego juego;

        private int[] cuadroSelect = new int[2];
        private int[] piezaSelect = new int[2];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            seleccionadoCuadrado = false;
            seleccionadaPieza = false;
            moverPieza = false;
            piezaMoviada = false;
            juego = new Juego();
            juego.TurnoBlancas = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            juego.iniciarJuego();
            tiempo = DateTime.Now.Ticks;
            tiempoMovimiento = DateTime.Now.Ticks;
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
            int margin = board.Height / 32;
            ladoCuadrado = (board.Height - margin - margin / 2) / 8;
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    posiciones[i,j] = new Vector2(margin + i * ladoCuadrado, margin + (7 - j) * ladoCuadrado);
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

            
            MouseState mouseState = Mouse.GetState();
            if (DateTime.Now.Ticks - tiempo > TimeSpan.TicksPerSecond/3) {
                if (ButtonState.Pressed == mouseState.LeftButton)
                {
                    seleccionarRaton(mouseState.Position);
                    tiempo = DateTime.Now.Ticks;
                }
            }

            if (moverPieza)
            {
                if (DateTime.Now.Ticks - tiempoMovimiento > TimeSpan.TicksPerSecond/3)
                {
                    movimientoCorrecto = juego.Tablero.mover(movimiento, true);// juego.TurnoBlancas);
                    if (movimientoCorrecto) juego.TurnoBlancas = !juego.TurnoBlancas;
                    //Console.WriteLine("movimiento Correcto: "+movimientoCorrecto);
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            dibujarTablero();

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void dibujarTablero()
        {
            spriteBatch.Draw(board, new Vector2(0,0), Color.White);
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
                        color = Color.Yellow;
                    }
                }
                spriteBatch.Draw(imagenPieza, posiciones[i, j], color);
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
                                movimiento = String.Format("{0}{1}{2}",
                                    movimiento,
                                    (char)('A'+i),
                                    j+1);
                                //Console.WriteLine(movimiento);
                                moverPieza = true;
                                tiempoMovimiento = DateTime.Now.Ticks;
                            }
                        }
                        else
                        {
                            piezaSelect[0] = i;
                            piezaSelect[1] = j;
                            seleccionadaPieza = true;
                            movimiento = String.Format("{0}{1}{2}",
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
