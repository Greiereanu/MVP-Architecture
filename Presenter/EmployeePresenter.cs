using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garden.Model;
using Garden.View;
using System.IO;
using Newtonsoft.Json;


namespace Garden.Presenter
{
    class EmployeePresenter
    {
        IEmployeeView formEmployee;
        PlantPersistance plantPersistance = new PlantPersistance();
        public EmployeePresenter(IEmployeeView view)
        {
            this.formEmployee = view;
        }

        public void ShowInfo()
        {
            List<Plant> result = plantPersistance.loadPlants();
            foreach (Plant plant in result)
                this.formEmployee.table.Rows.Add(plant.getName(), plant.getType(), plant.getSpecies(), plant.getIsCarnivorous(), plant.getGardenZone());
        }

        public void deletePlant()
        {
            if (this.formEmployee.name.Text == "")
            {
                MessageBox.Show("In order to delete a plant, enter its name!");
            }
            else
            {
                Plant p = plantPersistance.findPlant(this.formEmployee.name.Text);
                if (p.getName() == "not")
                {
                    MessageBox.Show("That plant doesn't exist!");
                }
                else
                {
                    plantPersistance.deletePlant(p);
                    this.formEmployee.table.Rows.Clear();
                    this.formEmployee.table.Refresh();
                    this.ShowInfo();
                }
            }
        }

        public void addPlant()
        {
            if (this.formEmployee.name.Text == "" || this.formEmployee.type.Text == "" || this.formEmployee.species.Text == "" || this.formEmployee.carnivorous.Text == "" || this.formEmployee.zone.Text == "")
            {
                MessageBox.Show("You must enter data in all of those fields!");
            }
            else
            {
                Plant p = new Plant(this.formEmployee.name.Text, this.formEmployee.type.Text, this.formEmployee.species.Text, this.formEmployee.carnivorous.Text, this.formEmployee.zone.Text);
                plantPersistance.savePlant(p);
                this.formEmployee.table.Rows.Clear();
                this.formEmployee.table.Refresh();
                this.ShowInfo();

            }
        }

        public void editPlant()
        {
            List<Plant> result = plantPersistance.loadPlants();
            Plant p = plantPersistance.findPlant(this.formEmployee.name.Text);
            if (p.getName() == "not")
            {
                MessageBox.Show("That plant doesn't exist!");
            }
            else
            {
                if (this.formEmployee.type.Text == "" || this.formEmployee.species.Text == "" || this.formEmployee.carnivorous.Text == "" || this.formEmployee.zone.Text == "")
                {
                    MessageBox.Show("You must provide all the data before editing!");
                }
                else
                {
                    Plant newPlant = new Plant(this.formEmployee.name.Text, this.formEmployee.type.Text, this.formEmployee.species.Text, this.formEmployee.carnivorous.Text, this.formEmployee.zone.Text);
                    plantPersistance.editPlant(p, newPlant);
                }
            }

            this.formEmployee.table.Rows.Clear();
            this.formEmployee.table.Refresh();
            List<Plant> after = plantPersistance.loadPlants();
            foreach (Plant plant in after)
                this.formEmployee.table.Rows.Add(plant.getName(), plant.getType(), plant.getSpecies(), plant.getIsCarnivorous(), plant.getGardenZone());
        }

        public void generateReports()
        {
            List<Plant> result = plantPersistance.loadPlants();
            
            if(this.formEmployee.selection.Text=="CSV")
            {
                var filepath = "../../data/CSV_Report.csv";
                using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Create, FileAccess.Write)))
                {
                    string fields = String.Format("Name,Type,Species,IsCarnivorous,Zone");
                    writer.WriteLine(fields);
                    foreach (Plant p in result)
                    {
                        string info = String.Format("{0},{1},{2},{3},{4}", p.getName(), p.getType(), p.getSpecies(),p.getIsCarnivorous(),p.getGardenZone());
                        writer.WriteLine(info);
                    }    
                }

                MessageBox.Show("CSV Report generated succesfully!");
            }
            if (this.formEmployee.selection.Text == "JSON")
            {
                var filepath = "../../data/JSON_Report.json";
                using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Create, FileAccess.Write)))
                {
                    foreach (Plant p in result)
                    {
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                        writer.WriteLine(json);
                    }
                }
                MessageBox.Show("JSON Report generated succesfully!");
            }
        }
    }
}
