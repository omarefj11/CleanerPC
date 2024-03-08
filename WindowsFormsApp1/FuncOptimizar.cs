using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;

namespace WindowsFormsApp1
{
    public class FuncOptimizar
    {
        public void TempWin()
        {
            // La ruta de la carpeta que quieres borrar
            string folderPath = @"C:\Windows\Temp";

            // Obtener todos los archivos dentro de la carpeta
            string[] files = Directory.GetFiles(folderPath);

            // Borrar cada archivo usando un bucle
            foreach (string file in files)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el archivo actual por su ruta
                    File.Delete(file);
                }
                catch (IOException ec)
                {
                    // Mostrar el mensaje de error si el archivo está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(ec.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            // Opcionalmente, borrar también los subdirectorios dentro de la carpeta
            DirectoryInfo di = new DirectoryInfo(folderPath);

            // Obtener todos los subdirectorios dentro de la carpeta
            DirectoryInfo[] subdirs = di.GetDirectories();

            // Borrar cada subdirectorio usando un bucle
            foreach (DirectoryInfo subdir in subdirs)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el subdirectorio actual por su ruta
                    Directory.Delete(subdir.FullName, true);
                }
                catch (IOException es)
                {
                    // Mostrar el mensaje de error si el subdirectorio está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        
        public void TempUser()
        {
            // Eliminar %temp%
            // La ruta de la carpeta %temp%
            string tempFolder = Environment.GetEnvironmentVariable("TEMP");

            // Usar un bloque try-catch para manejar las excepciones
            try
            {
                // Borrar la carpeta %temp% y todos sus archivos y subcarpetas
                Directory.Delete(tempFolder, true);
            }
            catch (IOException et)
            {
                // Mostrar el mensaje de error si la carpeta está en uso o no existe
                //Console.WriteLine(et.Message);
                MessageBox.Show(et.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void OptiPrefetch()
        {
            // La ruta de la carpeta que quieres borrar
            string folderPath2 = @"C:\Windows\Prefetch";

            // Obtener todos los archivos dentro de la carpeta
            string[] files2 = Directory.GetFiles(folderPath2);

            // Borrar cada archivo usando un bucle
            foreach (string file in files2)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el archivo actual por su ruta
                    File.Delete(file);
                }
                catch (IOException ec)
                {
                    // Mostrar el mensaje de error si el archivo está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(ec.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            // Opcionalmente, borrar también los subdirectorios dentro de la carpeta
            DirectoryInfo di2 = new DirectoryInfo(folderPath2);

            // Obtener todos los subdirectorios dentro de la carpeta
            DirectoryInfo[] subdirs2 = di2.GetDirectories();

            // Borrar cada subdirectorio usando un bucle
            foreach (DirectoryInfo subdir in subdirs2)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el subdirectorio actual por su ruta
                    Directory.Delete(subdir.FullName, true);
                }
                catch (IOException es)
                {
                    // Mostrar el mensaje de error si el subdirectorio está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void OptiDowl()
        {
            // La ruta de la carpeta que quieres borrar
            string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            // Obtener todos los archivos dentro de la carpeta
            string[] files2 = Directory.GetFiles(folderPath2);

            // Borrar cada archivo usando un bucle
            foreach (string file in files2)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el archivo actual por su ruta
                    File.Delete(file);
                }
                catch (IOException ec)
                {
                    // Mostrar el mensaje de error si el archivo está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(ec.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            // Opcionalmente, borrar también los subdirectorios dentro de la carpeta
            DirectoryInfo di2 = new DirectoryInfo(folderPath2);

            // Obtener todos los subdirectorios dentro de la carpeta
            DirectoryInfo[] subdirs2 = di2.GetDirectories();

            // Borrar cada subdirectorio usando un bucle
            foreach (DirectoryInfo subdir in subdirs2)
            {
                // Usar un bloque try-catch para manejar las excepciones
                try
                {
                    // Borrar el subdirectorio actual por su ruta
                    Directory.Delete(subdir.FullName, true);
                }
                catch (IOException es)
                {
                    // Mostrar el mensaje de error si el subdirectorio está en uso
                    //Console.WriteLine(e.Message);
                    MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void OpenPshell()
        {
            // Crear una instancia de PowerShell
            using (PowerShell ps = PowerShell.Create())
            {
                // Añadir el comando a ejecutar
                ps.AddCommand("Get-Process");

                // Invocar el comando y obtener los resultados
                var results = ps.Invoke();

                // Mostrar los resultados por consola
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
    }
}
