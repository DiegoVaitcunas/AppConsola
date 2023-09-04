using Dominio;
using System;
using System.Collections.Generic;
//En la clase program, realizamos todo el menu que cuenta con las 6 funciones posibles de la aplicacion.
//Hay una funcion extra que es la 7 que la usamos como ayuda para determinadas cosas. No esta pedida en la letra del obligatorio.
namespace obligatorio1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            InicializarSistema();
            //Aca realizamos el menu principal que se mostrara en la consola para que el usuario pueda ingresar unicamente un numero.
        #region MenuInicial
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("##### Bienvenido al sistema #####\n");
                Console.WriteLine("Por favor ingrese una opcion:");
                Console.WriteLine("Opcion 1- Dar de alta a un periodista");
                Console.WriteLine("Opcion 2- Asignar un valor de referencia para la categoria de los Jugadores");
                Console.WriteLine("Opcion 3- Buscar partidos del jugador por ID");
                Console.WriteLine("Opcion 4- Listar jugadores expulsados");
                Console.WriteLine("Opcion 5- Buscar partido con mas cantidad de goles");
                Console.WriteLine("Opcion 6- Listar jugadores que hayas hecho al menos un gol");
                Console.WriteLine("Opcion 7- Imprimir jugadores");
                Console.WriteLine("Opcion 8- Imprimir incidencias");
                Console.WriteLine("Opcion 0 - Salir del sistema");

                bool ok = int.TryParse(Console.ReadLine(), out int opcion); // Retorna true si se ingresa un numero y false si no, y al mismo tiempo se guarda el numero en "opcion"

                if (!ok)
                {
                    Console.WriteLine("Opción inválida. Debe ingresar números.");
                    Console.ReadLine();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            AltaPeriodista();
                            break;
                        case 2:
                            Console.Clear();
                            ValorReferencia();
                            break;
                        case 3:
                            Console.Clear();
                            ListarPartidosDeJugador();
                            break;
                        case 4:
                            Console.Clear();
                            ListarJugadoresExpulsados();
                            break;
                        case 5:
                            Console.Clear();
                            ListarPartidosConMasGoles();
                            break;
                        case 6:
                            Console.Clear();
                            ListarJugadoresConGoles();
                            break;
                        case 7:
                            Console.Clear();
                            ImprimirJugadores();
                            break;
                        case 8:
                            Console.Clear();
                            ImprimirIncidencias();
                            break;
                        case 0:
                            Console.Clear();
                            salir = true;
                            Console.WriteLine("Presione intro para salir del sistema");
                            break;
                        default:
                            salir = true;
                            break;

                    }
                }

            }
            #endregion
        #region Parte 1
            /*############################################### PARTE 1 ###############################################*/
            //Dar de alta a un periodista.
            static void AltaPeriodista()
            {

            bool salir = true;
                while (salir)
                {
                    Console.WriteLine("Ingrese su Nombre y Apellido");
                    string nombrePeriodista = Console.ReadLine().Trim();

                    Console.WriteLine("Ingrese su Email");
                    string mailPeriodista = Console.ReadLine();

                    Console.WriteLine("Ingrese su Contraseña");
                    string passwordPeriodista = Console.ReadLine();

                    salir = false;

                    try
                    {
                        Periodista unPeriodista = new Periodista(nombrePeriodista, mailPeriodista, passwordPeriodista);
                        Console.WriteLine(unPeriodista);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        salir = true;
                    }
                }
                Console.ReadKey();
            }
            #endregion
        #region parte 2
            /*############################################### PARTE 2 ###############################################*/
            //Cambiar valor de referencia a los jugadores.
            static void ValorReferencia()
            {
                bool repetir = false;
                Console.WriteLine("Usted escogio la opcion 2 \n ingrese el valor de referencia");
                while (!repetir)
                {
                    bool ok = decimal.TryParse(Console.ReadLine(), out decimal valorReferencia);
                
                if (valorReferencia >= 1 && ok) { 
                    try
                    {
                        Sistema unSistema = Sistema.Instancia; 
                        unSistema.ValorReferencia(valorReferencia);
                        Console.WriteLine($"Su nuevo valor de Referencia es {valorReferencia}");
                        repetir = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor de referencia debe ser mayor a 1 y debe ser un numero");
                    Console.WriteLine("Escriba nuevamente el valor de referencia");
                    repetir = false;
                }
                }
                Console.ReadKey();
            }
            #endregion
        #region Parte 3
            /*############################################### PARTE 3 ###############################################*/
            //Se listaran todos los partidos jugados dado un id del jugador
            static void ListarPartidosDeJugador(){
                Console.WriteLine("Usted escogio la opcion 3 \n Ingrese un id de un jugador");

                bool ok = int.TryParse(Console.ReadLine(), out int idJugador);

                if (ok)
                {
                    Sistema unSistema = Sistema.Instancia;

                    List<Partido> resultado = unSistema.ListarPartidos(idJugador);
                    List<Incidencia> incidencias = unSistema.Incidencias;

                    if (resultado.Count > 0)

                    {

                        foreach (Partido p in resultado)
                        {

                            Console.WriteLine($"Fecha y hora: {p.Fecha}");

                            foreach (Seleccion s in p.selecciones)
                            {
                                Console.WriteLine($"Seleccion: {s.unPais.Nombre}");

                            }
                            Console.WriteLine($"\n ******************* \n Incidencias: {unSistema.ListarIncidenciasPorPartido(p).Count}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Este jugador no jugo ningun partido");
                    }
                }
                else
                {
                    Console.WriteLine("Debe ingresar un numero");
                }
                Console.ReadKey();
            }
        }
        #endregion
        #region Parte 4
        /*############################################### PARTE 4 ###############################################*/
        //Se listaran los jugadores expulsados
        static void ListarJugadoresExpulsados()
        {
            Console.WriteLine("Usted escogio la opcion 4 \n A continuacion se listaran todos los jugadores que fueron expulsados...");

            try
            {
                Sistema unSistema = Sistema.Instancia;
                unSistema.ListarJugadoresExpulsados();
                foreach (Jugador j in unSistema.ListarJugadoresExpulsados())
                {
                    Console.WriteLine($"\n ############################### \n Nombre: {j.NombreCompleto} \n Precio {j.Valor} \n Altura: {j.Altura}\n Categoria: {j.Categoria}\n Dorsal: {j.Dorsal}\n Fecha de nacimiento: {j.FechaNacimiento}\n ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ReadKey();
        }
        #endregion
        #region Parte 5
        /*############################################### PARTE 5 ###############################################*/
        //Se listaran los partidos con mas goles segun el nombre de una seleccion que el usuario elija.
        static void ListarPartidosConMasGoles()
        {
            Console.WriteLine("Usted escogio la opcion 5 \n Ingrese el nombre de la seleccion");
            string nombreSeleccion = Console.ReadLine();
            
            try
            {
                Sistema unSistema = Sistema.Instancia;
                Partido p = unSistema.ListarPartidosConMasGoles(nombreSeleccion);
                Console.WriteLine($"\n ---------------------------- \n El partido con mas goles: \n Fecha y Hora del partido: {p.Fecha}\n \n Selecciones que participaron: " );

                int contador = 0;
                foreach (Seleccion s in p.selecciones)
                {
                    contador++;
                    Console.WriteLine($"Seleccion {contador}: {s.unPais.Nombre}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ReadKey();
        }
        #endregion
        #region Parte 6
        /*############################################### PARTE 6 ###############################################*/
        //Se listaran los jugadores que han hecho al menos un gol.
        static void ListarJugadoresConGoles()
        {
            Console.WriteLine("Usted escogio la opcion 6 \n A continuacion se listaran todos los jugadores que hicieron al menos un gol");
            try
            {
                Sistema unSistema = Sistema.Instancia;
                unSistema.ListarJugadoresConGoles();
                foreach (Jugador j in unSistema.ListarJugadoresConGoles())
                {
                    Console.WriteLine($"############################### \n Nombre: {j.NombreCompleto} \n Valor: {j.Valor}\n Categoria: {j.Categoria} \n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        #endregion
        #region MetodosGenericos
        static void InicializarSistema()
        {
            try
            {
                Sistema unSistema = Sistema.Instancia;
                unSistema.InicializarSistema();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Este codigo se realizo para saber si estan bien realizadas las precargas, igualmente es una opcion extra a la aplicacion.
        static void ImprimirJugadores()
        {
            Sistema unSistema = Sistema.Instancia;
            foreach (Jugador p in unSistema.Jugadores)
            {
                Console.WriteLine($"\n ****Jugador***** \n Nombre: {p.NombreCompleto} \n ValorReferencia: {p.Valor} \n Categoria: {p.Categoria} \n \n");
            }
            Console.ReadKey();
        }
        static void ImprimirIncidencias()
        {
            Sistema unSistema = Sistema.Instancia;
            foreach (Incidencia i in unSistema.Incidencias)
            {
                Console.WriteLine($"\n ****Jugador***** \n Minuto: {i.Minuto} \n Tipo: {i.Tipo} \n jugador: {i.unJugador.NombreCompleto} \n \n");
            }
            Console.ReadKey();
        }

        #endregion
    }
}