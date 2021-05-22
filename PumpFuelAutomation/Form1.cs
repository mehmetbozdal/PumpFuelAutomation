using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpFuelAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // for Warehouse_Benzin = Wh_benzin, Adding_benzin = A_benzin, Price_benzin = P_benzin, Sell_benzin = S_benzin
        double Wh_benzin95 = 0, Wh_benzin97 = 0, Wh_diesel = 0, Wh_eurodiesel = 0, Wh_lpg = 0;
        double A_benzin95 = 0, A_benzin97 = 0, A_diesel = 0, A_eurodiesel = 0, A_lpg = 0;
        double P_benzin95 = 0, P_benzin97 = 0, P_diesel = 0, P_eurodiesel = 0, P_lpg = 0;
        double S_benzin95 = 0, S_benzin97 = 0, S_diesel = 0, S_eurodiesel = 0, S_lpg = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string[] warehouse_informations;
        string[] price_informations;

        private void button3_Click(object sender, EventArgs e)
        {
            S_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_diesel = double.Parse(numericUpDown3.Value.ToString());
            S_eurodiesel = double.Parse(numericUpDown4.Value.ToString());
            S_lpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                Wh_benzin95 = Wh_benzin95 - S_benzin95;
                label29.Text = Convert.ToString(S_benzin95 * P_benzin95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                Wh_benzin97 = Wh_benzin97 - S_benzin97;
                label29.Text = Convert.ToString(S_benzin97 * P_benzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                Wh_diesel = Wh_diesel - S_diesel;
                label29.Text = Convert.ToString(S_diesel * P_diesel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                Wh_eurodiesel = Wh_eurodiesel - S_eurodiesel;
                label29.Text = Convert.ToString(S_eurodiesel * P_eurodiesel);
            }
            else if (numericUpDown5.Enabled == true)
            {
                Wh_lpg = Wh_lpg - S_lpg;
                label29.Text = Convert.ToString(S_lpg * P_lpg);
            }

            warehouse_informations[0] = Convert.ToString(Wh_benzin95);
            warehouse_informations[1] = Convert.ToString(Wh_benzin97);
            warehouse_informations[2] = Convert.ToString(Wh_diesel);
            warehouse_informations[3] = Convert.ToString(Wh_eurodiesel);
            warehouse_informations[4] = Convert.ToString(Wh_lpg);
            
            System.IO.File.WriteAllLines(Application.StartupPath + "\\warehouse.txt", warehouse_informations);
            txt_warehouse_read();
            txt_warehouse_write();
            progressBar_update();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }      
                
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Benzin (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Benzin (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Euro Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "_________";
        }              
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                P_benzin95 = P_benzin95 + (P_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                price_informations[0] = Convert.ToString(P_benzin95);

            }
            catch (Exception)
            {

                textBox6.Text = "Error!";
            }

            try
            {
                P_benzin97 = P_benzin97 + (P_benzin97 * Convert.ToDouble(textBox7.Text) / 100);
                price_informations[1] = Convert.ToString(P_benzin97);

            }
            catch (Exception)
            {

                textBox7.Text = "Error!";
            }

            try
            {
                P_diesel = P_diesel + (P_diesel * Convert.ToDouble(textBox8.Text) / 100);
                price_informations[2] = Convert.ToString(P_diesel);

            }
            catch (Exception)
            {

                textBox8.Text = "Error!";
            }

            try
            {
                P_eurodiesel = P_eurodiesel + (P_eurodiesel * Convert.ToDouble(textBox9.Text) / 100);
                price_informations[3] = Convert.ToString(P_eurodiesel);

            }
            catch (Exception)
            {

                textBox9.Text = "Error!";
            }

            try
            {
                P_lpg = P_lpg + (P_lpg * Convert.ToDouble(textBox10.Text) / 100);
                price_informations[4] = Convert.ToString(P_lpg);

            }
            catch (Exception)
            {

                textBox10.Text = "Error!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\price.txt", price_informations);
            txt_price_read();
            txt_price_write();

        }        
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                A_benzin95 = Convert.ToDouble(textBox1.Text);
                if (10000 < Wh_benzin95 + A_benzin95 || A_benzin95 <= 0)
                    textBox1.Text = "Error!";
                else
                    warehouse_informations[0] = Convert.ToString(Wh_benzin95 + A_benzin95);

            }
            catch (Exception)
            {

                textBox1.Text = "Error!";
            }

            try
            {
                A_benzin97 = Convert.ToDouble(textBox2.Text);
                if (10000 < Wh_benzin97 + A_benzin97 || A_benzin97 <= 0)
                    textBox2.Text = "Error!";
                else
                    warehouse_informations[1] = Convert.ToString(Wh_benzin97 + A_benzin97);

            }
            catch (Exception)
            {

                textBox2.Text = "Error!";
            }

            try
            {
                A_diesel = Convert.ToDouble(textBox3.Text);
                if (10000 < Wh_diesel + A_diesel || A_diesel <= 0)
                    textBox3.Text = "Error!";
                else
                    warehouse_informations[2] = Convert.ToString(Wh_diesel + A_diesel);

            }
            catch (Exception)
            {

                textBox3.Text = "Error!";
            }

            try
            {
                A_eurodiesel = Convert.ToDouble(textBox4.Text);
                if (10000 < Wh_eurodiesel + A_eurodiesel || A_eurodiesel <= 0)
                    textBox4.Text = "Error!";
                else
                    warehouse_informations[3] = Convert.ToString(Wh_eurodiesel + A_eurodiesel);

            }
            catch (Exception)
            {

                textBox4.Text = "Error!";
            }

            try
            {
                A_lpg = Convert.ToDouble(textBox5.Text);
                if (10000 < Wh_lpg + A_lpg || A_lpg <= 0)
                    textBox5.Text = "Error!";
                else
                    warehouse_informations[4] = Convert.ToString(Wh_lpg + A_lpg);

            }
            catch (Exception)
            {

                textBox5.Text = "Error!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\warehouse.txt", warehouse_informations);
            txt_warehouse_read();
            txt_warehouse_write();
            progressBar_update();
            numericupdown_value();
        }        

        //txt_warehouse_read will read warehouse informations
        private void txt_warehouse_read()
        {
            warehouse_informations = System.IO.File.ReadAllLines(Application.StartupPath + "\\warehouse.txt");
            Wh_benzin95 = Convert.ToDouble(warehouse_informations[0]);
            Wh_benzin97 = Convert.ToDouble(warehouse_informations[1]);
            Wh_diesel = Convert.ToDouble(warehouse_informations[2]);
            Wh_eurodiesel = Convert.ToDouble(warehouse_informations[3]);
            Wh_lpg = Convert.ToDouble(warehouse_informations[4]);
        }
        
        private void txt_warehouse_write()
        {
            label6.Text = Wh_benzin95.ToString("N");
            label7.Text = Wh_benzin97.ToString("N");
            label8.Text = Wh_diesel.ToString("N");
            label9.Text = Wh_eurodiesel.ToString("N");
            label10.Text = Wh_lpg.ToString("N");
        }

        private void txt_price_read()
        {
            price_informations = System.IO.File.ReadAllLines(Application.StartupPath + "\\price.txt");
            P_benzin95 = Convert.ToDouble(price_informations[0]);
            P_benzin97 = Convert.ToDouble(price_informations[1]);
            P_diesel = Convert.ToDouble(price_informations[2]);
            P_eurodiesel = Convert.ToDouble(price_informations[3]);
            P_lpg = Convert.ToDouble(price_informations[4]);
        }

        private void txt_price_write()
        {
            label16.Text = P_benzin95.ToString("N");
            label17.Text = P_benzin97.ToString("N");
            label18.Text = P_diesel.ToString("N");
            label19.Text = P_eurodiesel.ToString("N");
            label20.Text = P_lpg.ToString("N");
        }

        private void progressBar_update()
        {            
            progressBar1.Value = Convert.ToInt16(Wh_benzin95);
            progressBar2.Value = Convert.ToInt16(Wh_benzin97);
            progressBar3.Value = Convert.ToInt16(Wh_diesel);
            progressBar4.Value = Convert.ToInt16(Wh_eurodiesel);
            progressBar5.Value = Convert.ToInt16(Wh_lpg);
        }

        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(Wh_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(Wh_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(Wh_diesel.ToString());
            numericUpDown4.Maximum = decimal.Parse(Wh_eurodiesel.ToString());
            numericUpDown5.Maximum = decimal.Parse(Wh_lpg.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "PUMP FUEL AUTOMATION";
            progressBar1.Maximum = 10000;
            progressBar2.Maximum = 10000;
            progressBar3.Maximum = 10000;
            progressBar4.Maximum = 10000;
            progressBar5.Maximum = 10000;

            txt_warehouse_read();
            txt_warehouse_write();
            txt_price_read();
            txt_price_write();
            progressBar_update();
            numericupdown_value();

            string[] fuel_types = { "Benzin (95)", "Benzin (97)", "Diesel", "Euro Diesel", "LPG" };
            comboBox1.Items.AddRange(fuel_types);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

        }
    }
}
