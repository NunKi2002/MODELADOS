using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace MODELADOS
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private ChartValues<double> DesplazamientoValues;
        private ChartValues<double> VelocidadValues;
        private ChartValues<double> AceleracionValues;
        private ChartValues<DateTime> timeValues;
        private string dataFolderPath;
        private Timer captureTimer;
        private ChartValues<double> realTimeChart;

        public Form1()
        {
            InitializeComponent();

            serialPort = new SerialPort();
            serialPort.PortName = "COM12";  // Ajusta el nombre del puerto según tu configuración
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;

            try
            {
                serialPort.Open();
                serialPort.DataReceived += SPpuertos_DataReceived;

                DesplazamientoValues = new ChartValues<double>();
                VelocidadValues = new ChartValues<double>();
                AceleracionValues = new ChartValues<double>();
                timeValues = new ChartValues<DateTime>();

                ChartDesplazamiento.Series.Add(new LineSeries
                {
                    Title = "Desplazamiento",
                    Values = DesplazamientoValues,
                    ScalesYAt = 0,
                    ScalesXAt = 0
                });

                ChartVelocidad.Series.Add(new LineSeries
                {
                    Title = "Velocidad",
                    Values = VelocidadValues,
                    ScalesYAt = 0,
                    ScalesXAt = 0
                });

                ChartAceleracion.Series.Add(new LineSeries
                {
                    Title = "Aceleracion",
                    Values = AceleracionValues,
                    ScalesYAt = 0,
                    ScalesXAt = 0
                });

                ChartDesplazamiento.AxisX.Add(new Axis
                {
                    Title = "Time",
                    LabelFormatter = value => new DateTime((long)value).ToString("HH:mm:ss")
                });

                ChartVelocidad.AxisX.Add(new Axis
                {
                    Title = "Time",
                    LabelFormatter = value => new DateTime((long)value).ToString("HH:mm:ss")
                });

                captureTimer = new Timer();
                captureTimer.Interval = 5000;
                captureTimer.Tick += CaptureTimer_Tick;
                captureTimer.Start();

                dataFolderPath = @"C:\Users\kaus_\OneDrive\Documentos\codigos INO\MODELADO.PROYECTO";  // Reemplaza esto con la ruta correcta a tu directorio de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el puerto serial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Puedes decidir cerrar la aplicación o manejar de otra manera en caso de error al abrir el puerto.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Puedes agregar código aquí que necesite ejecutarse después de que el formulario esté completamente cargado
        }

        public void CaptureTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("CaptureTimer_Tick ejecutándose...");
                // Tu lógica aquí
                Console.WriteLine("CaptureTimer_Tick completado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CaptureTimer_Tick: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error en CaptureTimer_Tick: {ex.Message}");
            }
        }

        public void SPpuertos_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!IsDisposed && InvokeRequired)
                {
                    string data = serialPort.ReadLine();
                    if (string.IsNullOrEmpty(data))
                    {
                        return;
                    }

                    string[] values = data.Split(',');
                    if (values.Length == 3)
                    {
                        string Desplazamiento = values[0];
                        string velocidad = values[1];
                        string aceleracion = values[2];

                        double DesplazamientoValue, VelocidadValue, AceleracionValue;
                        bool isDesplazamientoValid = double.TryParse(Desplazamiento, out DesplazamientoValue);
                        bool isVelocidadValid = double.TryParse(velocidad, out VelocidadValue);
                        bool isAceleracionValid = double.TryParse(aceleracion, out AceleracionValue);

                        Invoke(new Action(() =>
                        {
                            DesplazamientoValues.Add(DesplazamientoValue);
                            if (DesplazamientoValues.Count > 1000)
                                DesplazamientoValues.RemoveAt(0);

                            VelocidadValues.Add(VelocidadValue);
                            if (VelocidadValues.Count > 1000)
                                VelocidadValues.RemoveAt(0);

                            AceleracionValues.Add(AceleracionValue);
                            if (AceleracionValues.Count > 1000)
                                AceleracionValues.RemoveAt(0);
                        }));

                        SaveData(DesplazamientoValue, VelocidadValue, AceleracionValue);
                    }
                }
                else
                {
                    Console.WriteLine("Error: Sender is not a SerialPort");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar los datos: {ex.Message}");
            }
        }

        private void SaveData(double Desplazamiento, double Velocidad, double Aceleracion)
        {
            {
                try
                {
                    string fileName = $"DataLog_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    string filePath = Path.Combine(dataFolderPath, fileName);

                    bool fileExists = File.Exists(filePath);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine("DateTime,Desplazamiento,Velocidad,Aceleracion");
                        }

                        writer.WriteLine($"{DateTime.Now},{Desplazamiento},{Velocidad},{Aceleracion}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                /*try
                {
                    string fileName = "DataLog.csv";
                    string filePath = Path.Combine(dataFolderPath, fileName);

                    bool fileExists = File.Exists(filePath);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine("DateTime,Desplazamiento,Velocidad,Aceleracion");
                        }

                        writer.WriteLine($"{DateTime.Now},{Desplazamiento},{Velocidad},{Aceleracion}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
}
        private void Graficas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void Desplazamiento_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
         
        }

      
    }
}



