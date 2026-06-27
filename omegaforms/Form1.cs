using System;
using System.Windows.Forms;

namespace omegaforms
{
    public partial class Form1 : Form
    {
        // Máquina de estados para rastrear la historia original
        private enum EstadoJuego
        {
            MenuPrincipal,
            EventoDanosNave,
            EventoRobots,
            SubEventoRobotsCama,
            EventoGritar,
            SubEventoGritarAlien,
            FinDelJuego
        }

        private EstadoJuego estadoActual;
        private Astronauta jugador;

        public Form1()
        {
            InitializeComponent();

            // Inicio astronauta
            jugador = new Astronauta("Arturo");

            // start game
            CambiarEstado(EstadoJuego.MenuPrincipal);
        }

        private void CambiarEstado(EstadoJuego nuevoEstado)
        {
            estadoActual = nuevoEstado;
            ActualizarInterfaz();

            // Validar derrota inmediata
            if (jugador.Vida <= 0)
            {
                txtNarrativa.Text = ">>> GAME OVER: Has muerto en el espacio profundo.";
                ConfigurarBotones(false, false, false);
                return;
            }
            if (jugador.Energia <= 0)
            {
                txtNarrativa.Text = ">>> GAME OVER: Te quedaste sin energía y te asfixiaste.";
                ConfigurarBotones(false, false, false);
                return;
            }

            switch (estadoActual)
            {
                case EstadoJuego.MenuPrincipal:
                    txtNarrativa.Text = "-- Navegación --\r\n\r\n1. Ver daños de la nave\r\n2. Buscar Robots de ayuda\r\n3. Gritar por ayuda";
                    btnOpcion1.Text = "Ver daños de la nave";
                    btnOpcion2.Text = "Buscar Robots";
                    btnOpcion3.Text = "Gritar por ayuda";
                    btnOpcion3.Visible = true;
                    break;

                case EstadoJuego.EventoDanosNave:
                    jugador.GastarEnergia(15);
                    jugador.AgregarInventario("Mapa de la nave");
                    ActualizarInterfaz();

                    txtNarrativa.Text = "Inspeccionas la nave... solo suenan sirenas de alerta por todas partes.\r\n\r\n" +
                                        "Despliegas el 'Mapa de la nave' en tu pantalla holográfica. Muestra dos posibles rutas de escape antes de que los sistemas colapsen:\r\n\r\n" +
                                        "1. Seguir la ruta mas larga que cruza toda la nave hacia las capsulas de escape.\r\n" +
                                        "2. Tomar un atajo por los conductos de ventilación marcados en rojo hacia la sala médica.";

                    btnOpcion1.Text = "Ruta Larga (Cápsulas)";
                    btnOpcion2.Text = "Atajo Rojo (Sala Médica)";
                    btnOpcion3.Visible = false;
                    break;

                case EstadoJuego.EventoRobots:
                    txtNarrativa.Text = "Llegas al pasillo central y ves a tres robots de mantenimiento. Sus ojos están en rojo intenso: un golpe desestabilizó su sistema.\r\n\r\n" +
                                        "1. Te escondes bajo una cama, los observas con mucho cuidado.\r\n" +
                                        "2. Salir de tu escondite e intentar hablarles por el comunicador.";
                    btnOpcion1.Text = "Esconderse bajo la cama";
                    btnOpcion2.Text = "Intentar hablarles";
                    btnOpcion3.Visible = false;
                    break;

                case EstadoJuego.SubEventoRobotsCama:
                    txtNarrativa.Text = "Los robots escanean la habitacion completa con un laser. ¡Han detectado tu posición! Se acercan rápidamente a la cama.\r\n\r\n" +
                                        "A. Salir con los brazos en alto rindiéndote.\r\n" +
                                        "B. Intentar atacar al primer robot que se acerque.";
                    btnOpcion1.Text = "Rendirse (A)";
                    btnOpcion2.Text = "Atacar (B)";
                    btnOpcion3.Visible = false;
                    break;

                case EstadoJuego.EventoGritar:
                    txtNarrativa.Text = "Empiezas a gritar pidiendo ayuda por los pasillos vacíos...\r\n\r\n" +
                                        "1. Seguir gritando y golpear las paredes de metal.\r\n" +
                                        "2. Callarte de golpe porque crees haber escuchado algo respondiendo.";
                    btnOpcion1.Text = "Seguir gritando";
                    btnOpcion2.Text = "Callarse de golpe";
                    btnOpcion3.Visible = false;
                    break;

                case EstadoJuego.SubEventoGritarAlien:
                    txtNarrativa.Text = "Te quedas en silencio total. Escuchas el chasquido de garras contra el piso. De las sombras emerge un alien.\r\n\r\n" +
                                        "A. Intentar comunicarte con el alien.\r\n" +
                                        "B. Correr en dirección contraria con todas tus fuerzas (-50 Energía).";
                    btnOpcion1.Text = "Comunicarse (A)";
                    btnOpcion2.Text = "Correr desesperadamente (B)";
                    btnOpcion3.Visible = false;
                    break;
            }
        }

        // --- CLIC BOTÓN 1 ---
        private void btnOpcion1_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoJuego.MenuPrincipal)
            {
                CambiarEstado(EstadoJuego.EventoDanosNave);
            }
            else if (estadoActual == EstadoJuego.EventoDanosNave)
            {
                txtNarrativa.Text = "Sigues el mapa cuidadosamente. Aunque es un camino largo, logras esquivar los sectores despresurizados.\r\n\r\n" +
                                    "Luegos a una cápsula de escape intacta, te abrochas el cinturón y te eyectas hacia el espacio seguro. ¡MISIÓN SUPERADA!";
                ConfigurarBotones(false, false, false);
            }
            else if (estadoActual == EstadoJuego.EventoRobots)
            {
                CambiarEstado(EstadoJuego.SubEventoRobotsCama);
            }
            else if (estadoActual == EstadoJuego.SubEventoRobotsCama)
            {
                txtNarrativa.Text = "Levantas las manos, pero estos robots no entienden que es rendirse. Te identifican como una amenaza letal.";
                jugador.RecibirAtaque(100);
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
            else if (estadoActual == EstadoJuego.EventoGritar)
            {
                txtNarrativa.Text = "Tus gritos resuenan en la estación. De repente, el panel del techo se cae. Un alien que te perseguía cae sobre ti.\r\n" +
                                    "Nunca debiste hacer tanto ruido en el espacio profundo.";
                jugador.RecibirAtaque(100);
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
            else if (estadoActual == EstadoJuego.SubEventoGritarAlien)
            {
                txtNarrativa.Text = "Gritas '¡No soy amenaza!'. El alien te mira confundido, no entiende tu idioma y te desgarra el cuerpo.";
                jugador.RecibirAtaque(100);
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
        }

        // --- CLIC BOTÓN 2 ---
        private void btnOpcion2_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoJuego.MenuPrincipal)
            {
                CambiarEstado(EstadoJuego.EventoRobots);
            }
            else if (estadoActual == EstadoJuego.EventoDanosNave)
            {
                txtNarrativa.Text = "Te metes a los conductos guiándote por el mapa, pero están llenos de cables pelados y fugas de líquido tóxico. Una explosión quema tu traje.";
                jugador.RecibirAtaque(95);
                ActualizarInterfaz();

                if (jugador.Vida > 0)
                {
                    txtNarrativa.Text += "\r\n\r\nCaes del conducto directamente al sector médico, casi muerto. Logras inyectarte un estabilizador celular justo a tiempo y te encierras en una cápsula criogénica. ¡Sobrevives de puro milagro!";
                    ConfigurarBotones(false, false, false);
                }
                else
                {
                    CambiarEstado(EstadoJuego.FinDelJuego);
                }
            }
            else if (estadoActual == EstadoJuego.EventoRobots)
            {
                txtNarrativa.Text = "Das un paso al frente y enciendes tu radio. Los robots giran sus cabezas hacia ti simultáneamente. Antes de que digas una palabra, las puertas magnéticas se sellan. Estás atrapado.";
                jugador.RecibirAtaque(100);
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
            else if (estadoActual == EstadoJuego.SubEventoRobotsCama)
            {
                txtNarrativa.Text = "Atacas al robot, pero su chasis es de titanio. Rebotas y caes al suelo, muriendo bajo los ataques de los otros 2 robots.";
                jugador.RecibirAtaque(100);
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
            else if (estadoActual == EstadoJuego.EventoGritar)
            {
                CambiarEstado(EstadoJuego.SubEventoGritarAlien);
            }
            else if (estadoActual == EstadoJuego.SubEventoGritarAlien)
            {
                jugador.GastarEnergia(50);
                ActualizarInterfaz();

                if (jugador.Energia > 0)
                {
                    txtNarrativa.Text = "Empiezas a correr desesperadamente. Logras perderlo al meterte en un conducto de ventilación, pero el conducto cierra el paso automáticamente al detectar un objeto. Te quedas atrapado sin oxígeno.";
                    jugador.RecibirAtaque(100);
                }
                CambiarEstado(EstadoJuego.FinDelJuego);
            }
        }

        // --- CLIC BOTÓN 3 ---
        private void btnOpcion3_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoJuego.MenuPrincipal)
            {
                CambiarEstado(EstadoJuego.EventoGritar);
            }
        }

        // --- MÉTODOS AUXILIARES ---
        private void ActualizarInterfaz()
        {
            prgVida.Value = Math.Max(0, Math.Min(100, jugador.Vida));
            prgEnergia.Value = Math.Max(0, Math.Min(100, jugador.Energia));

            // Funciona tanto para ListBox como para CheckedListBox
            lstInventario.Items.Clear();
            foreach (var item in jugador.Inventario)
            {
                lstInventario.Items.Add(item);
            }
        }

        private void ConfigurarBotones(bool op1, bool op2, bool op3)
        {
            btnOpcion1.Enabled = op1;
            btnOpcion2.Enabled = op2;
            btnOpcion3.Enabled = op3;
        }
    }
}