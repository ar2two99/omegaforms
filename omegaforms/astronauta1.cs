using System;
using System.Collections.Generic;

namespace omegaforms
{
    public class Astronauta
    {
        // Datos del astronauta
        public string Nombre { get; private set; }
        public int Vida { get; private set; }
        public int Energia { get; private set; }
        public List<string> Inventario { get; private set; }

        // Datos al iniciar 
        public Astronauta(string nombrejugador)
        {
            Nombre = nombrejugador;
            Vida = 100;
            Energia = 100;
            Inventario = new List<string>();
        }

        // Acciones del astronauta
        public void RecibirAtaque(int cantidad)
        {
            Vida -= cantidad;
        }

        public void GastarEnergia(int cantidad)
        {
            Energia -= cantidad;
        }

        public void AgregarInventario(string item)
        {
            Inventario.Add(item);
        }
    }
}