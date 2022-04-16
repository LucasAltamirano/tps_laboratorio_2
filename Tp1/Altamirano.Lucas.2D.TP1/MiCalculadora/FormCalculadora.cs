using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //( )))
            if (!(string.IsNullOrEmpty(txtNumero1.Text) || string.IsNullOrEmpty(txtNumero2.Text)))
            {
                if (cmbOperador.Text != "")
                {
                    double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

                    lblResultado.Text = resultado.ToString();

                    string operaciones = $"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}";
                    lstOperaciones.Items.Insert(0, operaciones);
                }
                else
                {
                    string ventana = "Error";
                    string msj = " Ingrese un operador valido + - / * .";
                    MessageBox.Show(msj, ventana, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            else
            {
                string ventana = "Error";
                string msj = "Verifique Operadores ";
                MessageBox.Show(msj, ventana, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        ///  Boton Limpiar , llama a la funcion Limpiar() ;
        ///  si se presiona el boton nuevamente limpiara tambien el List Box operacines :
        /// </summary>

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumero1.Text) && string.IsNullOrEmpty(txtNumero2.Text) && string.IsNullOrEmpty(lblResultado.Text) && string.IsNullOrEmpty(cmbOperador.Text))
            {
                lstOperaciones.Items.Clear();
            }
            else
            {
                Limpiar();
            }


        }



        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string strBinario = Operando.DecimalBinario(lblResultado.Text);
            lblResultado.Text = strBinario;

            lstOperaciones.Items.Insert(0, strBinario);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            string strDecimal = Operando.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = strDecimal;

            lstOperaciones.Items.Insert(0, strDecimal);
        }


        /// <summary>
        /// Limpia los textos de los textbox 1 y 2 ,el label resultado 
        /// y vuelve el combo box correspondiente al operador matematico a su valor por defecto;
        /// </summary>

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();

        }

        /// <summary>
        /// recibira como atributo la informacion indicada por el usuario ,convirtiendola en objetos del tipo Operando,
        /// para asi con esos objetos llamar la funcion Calculadora.Operar ()para realizar el calculo matematico correspondiente.
        /// </summary>
        /// <param name="numero1">Argumento de tipo string que se convertira en el 1er operando </param>
        /// <param name="numero2">Argumento de tipo string que se convertira en el 2do operando</param>
        /// <param name="operador">Argumento de tipo string que se convertira en el operador matematico</param>
        /// <returns> un valor del tipo double correspondiente al resultado de dicha operacion matematica </returns>
        static double Operar(string numero1, string numero2, string operador)
        {

            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            return Calculadora.Operar(num1, num2, Convert.ToChar(operador));
        }



        private void btnCerrrar_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs cerrarForm)
        {
            string ventana = "Salir";
            string msj = "¿Está seguro de querer salir ? ";
            DialogResult close = MessageBox.Show(msj, ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (close == DialogResult.No)
            {
                cerrarForm.Cancel = true;
            }
        }


        /// <summary>
        /// Se procedio a generar el evento KeyPress del txtNumero1
        /// por el cual  se permite solo el ingreso de numeros y el caracter "-".
        /// </summary>

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '-')
            {
                e.Handled = false;

            }
            else if (Char.IsDigit(e.KeyChar))

            {

                e.Handled = false;

            }

            else if (Char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }


            else

            {

                e.Handled = true;

            }
        }
        /// <summary>
        ///   /// <summary>
        /// Se procedio a generar el evento KeyPress del txtNumero2
        /// por el cual  se permite solo el ingreso de numeros y el caracter "-".
        /// </summary>
        /// </summary>

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = false;

            }
            else if (Char.IsDigit(e.KeyChar))

            {

                e.Handled = false;

            }

            else if (Char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }


            else

            {

                e.Handled = true;

            }

        }
    }
}