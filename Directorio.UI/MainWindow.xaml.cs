using Directorio.UI.Models;
using Directorio.UI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Directorio.UI
{
    public partial class MainWindow : Window
    {
        private readonly PersonaService _service;
        private List<Persona> _personas;

        public MainWindow()
        {
            InitializeComponent();
            _service = new PersonaService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await CargarPersonas();
        }

        private async Task CargarPersonas()
        {
            _personas = await _service.ObtenerPersonas();
            lstPersonas.ItemsSource = null;
            lstPersonas.ItemsSource = _personas;
        }

        private async void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersonas.SelectedItem is Persona persona)
            {
                var confirm = MessageBox.Show($"¿Deseas eliminar a {persona.NombreCompleto}?", "Confirmar", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    var success = await _service.EliminarPersona(persona.Id);
                    if (success)
                    {
                        MessageBox.Show("Eliminado correctamente");
                        _personas.Remove(persona); 
                        lstPersonas.ItemsSource = null;
                        lstPersonas.ItemsSource = _personas;
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una persona");
            }
        }

        private async void Registrar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("Nombre, Apellido Paterno e Identificación son obligatorios.");
                return;
            }

            var persona = new Persona
            {
                Nombre = txtNombre.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Identificacion = txtIdentificacion.Text
            };

            var success = await _service.RegistrarPersona(persona);
            if (success)
            {
                MessageBox.Show("Registrado correctamente");
                LimpiarFormulario();
                await CargarPersonas();
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtIdentificacion.Text = "";

            LimpiarErroresVisuales();
            btnRegistrar.IsEnabled = false;
        }



        private void ValidarCampo(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag is string errorLabelName)
            {
                var errorLabel = (TextBlock)this.FindName(errorLabelName);
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BorderBrush = Brushes.Red;
                    errorLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    textBox.ClearValue(Border.BorderBrushProperty);
                    errorLabel.Visibility = Visibility.Collapsed;
                }

                btnRegistrar.IsEnabled = ValidarFormulario();
            }
        }

        private bool ValidarFormulario()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text)
                && !string.IsNullOrWhiteSpace(txtApellidoPaterno.Text)
                && !string.IsNullOrWhiteSpace(txtIdentificacion.Text);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void LimpiarErroresVisuales()
        {
            txtNombre.ClearValue(Border.BorderBrushProperty);
            lblNombreError.Visibility = Visibility.Collapsed;

            txtApellidoPaterno.ClearValue(Border.BorderBrushProperty);
            lblApellidoPaternoError.Visibility = Visibility.Collapsed;

            txtIdentificacion.ClearValue(Border.BorderBrushProperty);
            lblIdentificacionError.Visibility = Visibility.Collapsed;
        }
    }
}
