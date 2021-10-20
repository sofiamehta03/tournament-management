using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssignmentLibrary;

namespace Assignment4
{

    /*
     Group 4:
    Kanishk Sachdeva (301182362)
    Sofia Mehta (301171210)
    Jasleen Kaur (301178107)
     */

    public partial class Assignment4 : Form
    {
        BindingSource clubsBind = new BindingSource();
        List<Club> clubs = new List<Club>();
        IClubsRepository clbMngr = new ClubsManager();
        BindingSource swimmerBind = new BindingSource();
        List<Swimmer> swimmersinclub = new List<Swimmer>();


        BindingSource AllSwimmersBind = new BindingSource();
        List<Swimmer> allswimmers = new List<Swimmer>();
        ISwimmersRepository swmMngr = new SwimmersManager();

        public Assignment4()
        {
            InitializeComponent();

            

            clubsBind.DataSource = clubs;
            clubsList.DataSource = clubsBind;
            clubsList.DisplayMember = "Name";
            clubsList.ValueMember = "Name";

            numberOfClubsLoad.Value = 20;



            AllSwimmersBind.DataSource = allswimmers;
            swimmerslistbox.DataSource = AllSwimmersBind;
            swimmerslistbox.DisplayMember = "Name";
            swimmerslistbox.ValueMember = "Name";

            swimmerBind.DataSource = swimmersinclub;
            swimmersinclubList.DataSource = swimmerBind;
            swimmersinclubList.DisplayMember = "Name";
            swimmersinclubList.ValueMember = "Name";

            swimmersnumericUpDown1.Value = 20;

            try
            {
                swmMngr.LoadSwimmers(@"Swimmers.txt", ",");
            }
            catch (Exception ea)
            {
                string error = ea.Message;
            }
            try
            {
                clbMngr.LoadClubs(@"Clubs.txt", ",");
            }
            catch (Exception ea)
            {
                string error = ea.Message;
            }

            foreach (Club c in clbMngr.Clubs)
            {
                clubs.Add(c);
            }

            foreach (Swimmer s in swmMngr.Swimmers)
            {
                allswimmers.Add(s);
            }

            AllSwimmersBind.ResetBindings(false);
            clubsBind.ResetBindings(false);

            foreach (Club c in clbMngr.Clubs)
            {
                clubscombobox.Items.Add(c.Name);
                clubswimmerbox.Items.Add(c.Name);
            }

            foreach (Swimmer s in swmMngr.Swimmers)
            {
                swimmerscombobox.Items.Add(s.Name);
            }
            /*swimmerscombobox.SelectedIndex = 0;
            clubscombobox.SelectedIndex = 0;*/



        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clubs.Clear();
            clubsBind.ResetBindings(false);

            if (filePath.Text != "" && filePath.Text != null)
            {
                try
                {
                    clbMngr.LoadClubs(filePath.Text, ",");
                } catch
                {

                }

                for (int i = 0; i < clbMngr.Clubs.Count && i < numberOfClubsLoad.Value; i++)
                {
                    clubs.Add(clbMngr.Clubs[i]);
                    clubsBind.ResetBindings(false);

                    swimmersInClub.Text = "Swimmers in " + clbMngr.Clubs[clubsList.SelectedIndex].Name;
                }


            } 
            else
            {
                MessageBox.Show("File path is empty !", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clubsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            swimmersinclub.Clear();
            swimmerBind.ResetBindings(false);

            foreach(Swimmer s in clbMngr.Clubs[clubsList.SelectedIndex].Swimmers)
            {
                swimmersinclub.Add(s);
            }

           
            swimmerBind.ResetBindings(false);

            swimmersInClub.Text = "Swimmers in " + clbMngr.Clubs[clubsList.SelectedIndex].Name;

            Club club = clbMngr.Clubs[clubsList.SelectedIndex];
            idofclub.Text = Convert.ToString(club.ClubNumber);
            nameoftheclub.Text = club.Name;
            stnameclub.Text = club.ClubAddress.StreetName;
            stcityclub.Text = club.ClubAddress.StreetCity;
            stprovinceclub.Text = club.ClubAddress.StreetProvince;
            stpostalcodeclub.Text = club.ClubAddress.PostalCode;
            clubphoneno.Text = Convert.ToString(club.PhoneNumber);


        }

        private void addtoclub_Click(object sender, EventArgs e)
        {
            if(nameofclubtextbox.Text != "" && streetNametextBox.Text != "" && 
                streetcitytextbox.Text != "" && provincetextbox.Text != "" && postalcodetextbox.Text != "" &&
                phonenumbertextbox.Text != "")
            {

                
                try
                {
                    clbMngr.processClubRecord($"{RegistrationNumberGenerator.GetId()},{nameofclubtextbox.Text},{streetNametextBox.Text},{streetcitytextbox.Text},{provincetextbox.Text},{postalcodetextbox.Text},{phonenumbertextbox.Text}", ",");
                    clubs.Add(new Club(nameofclubtextbox.Text, new Address(streetNametextBox.Text, streetcitytextbox.Text, provincetextbox.Text, postalcodetextbox.Text), Convert.ToUInt64(phonenumbertextbox.Text)));

                    clubsBind.ResetBindings(false);
                    MessageBox.Show("Club is added to the list and don't forget to click on save club button to save club in filepath", "Success",
        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

            }
            else {
                MessageBox.Show("Some of the fields are empty in club adder are empty or incorrect !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveclubsbtn_Click(object sender, EventArgs e)
        {
            if(filePath.Text != "")
            {
                clbMngr.SaveClubs(filePath.Text, ",");
                MessageBox.Show("All the clubs are added to above file path and saved", "Success",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("File path is empty !", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void swimmersloadbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                swimmersFilePath.Text = openFileDialog2.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            allswimmers.Clear();
            AllSwimmersBind.ResetBindings(false);

            if (swimmersFilePath.Text != "" && swimmersFilePath.Text != null)
            {
                try
                {
                    swmMngr.LoadSwimmers(swimmersFilePath.Text, ",");
                }
                catch
                {

                }

                for (int i = 0; i < swmMngr.Swimmers.Count && i < swimmersnumericUpDown1.Value; i++)
                {
                    allswimmers.Add(swmMngr.Swimmers[i]);
                    AllSwimmersBind.ResetBindings(false);

                }


            }
            else
            {
                MessageBox.Show("File path is empty !", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void swimmerslistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Swimmer swimmer = swmMngr.Swimmers[swimmerslistbox.SelectedIndex];
            idofplayer.Text = Convert.ToString(swimmer.Id);
            nameofswimmer.Text = swimmer.Name;
            dobswimmer.Text = $"{swimmer.DateOfBirth.Year}/{swimmer.DateOfBirth.Month}/{swimmer.DateOfBirth.Day}";
            streetnameofplayer.Text = swimmer.Address.StreetName;
            streetcityofplayer.Text = swimmer.Address.StreetCity;
            provinceofplayer.Text = swimmer.Address.StreetProvince;
            postalcodeofplayer.Text = swimmer.Address.PostalCode;
            phonenumberofplayer.Text = Convert.ToString(swimmer.PhoneNumber);
        }

        private void submitassignbtn_Click(object sender, EventArgs e)
        {
            clbMngr.Clubs[clubscombobox.SelectedIndex].AddSwimmer(swmMngr.Swimmers[swimmerscombobox.SelectedIndex]);

            swimmersinclub.Clear();
            swimmerBind.ResetBindings(false);

            foreach (Swimmer s in clbMngr.Clubs[clubsList.SelectedIndex].Swimmers)
            {
                swimmersinclub.Add(s);
            }


            swimmerBind.ResetBindings(false);

            swimmerBind.ResetBindings(false);
            MessageBox.Show($"{swimmerscombobox.SelectedItem} is successfully added to {clubscombobox.SelectedItem}", "Success",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addswimmer_Click(object sender, EventArgs e)
        {
            if (nameofplayertextbox.Text != "" && stnametextbox.Text != "" && stcitytextbox.Text != "" && stprovincetextbox.Text != "" 
                && postalcodestbox.Text != "" && stphonenumber.Text != "" && datetimepickerswimmer != null 
                && clubswimmerbox.Text != "")
            {

                try
                {
                    swmMngr.processSwimmerRecord($"{RegistrationNumberGenerator.GetId()},{nameofplayertextbox.Text},{datetimepickerswimmer.Value},{stnametextbox.Text},{stcitytextbox.Text},{stprovincetextbox.Text},{postalcodestbox.Text},{stphonenumber.Text}", ",");
                    Swimmer swimmer1 = new Swimmer(nameofplayertextbox.Text, datetimepickerswimmer.Value, new Address(stnametextbox.Text, stcitytextbox.Text, stprovincetextbox.Text, postalcodestbox.Text), Convert.ToUInt64(stphonenumber.Text));
                    allswimmers.Add(swimmer1);

                    AllSwimmersBind.ResetBindings(false);


                    clbMngr.Clubs[clubswimmerbox.SelectedIndex].AddSwimmer(swimmer1);

                    swimmersinclub.Clear();
                    swimmerBind.ResetBindings(false);

                    foreach (Swimmer s in clbMngr.Clubs[clubsList.SelectedIndex].Swimmers)
                    {
                        swimmersinclub.Add(s);
                    }


                    swimmerBind.ResetBindings(false);

                    MessageBox.Show("Swimmer is added to the list and don't forget to click on save swimmer button to save club in filepath", "Success",
        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Some of the fields are empty in swimmer adder are empty or incorrect !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveSwimmers_Click(object sender, EventArgs e)
        {
            if (swimmersFilePath.Text != "")
            {
                swmMngr.SaveSwimmers(swimmersFilePath.Text, ",");
                MessageBox.Show("All the swimmers are added to above file path and saved", "Success",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("File path is empty !", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
