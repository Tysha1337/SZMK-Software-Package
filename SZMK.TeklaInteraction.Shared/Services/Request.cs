using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Models;

namespace SZMK.TeklaInteraction.Shared.Services
{
    public class Request
    {
        private readonly DataBase db;
        public Request()
        {
            db = new DataBase();
        }
        public List<Role> GetAllRole()
        {
            try
            {
                List<Role> Roles = new List<Role>();
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"Name\"" +
                                                            "FROM public.\"Position\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Roles.Add(new Role(Reader.GetInt64(0), Reader.GetString(1)));
                            }
                        }
                    }

                    Connect.Close();
                }

                return Roles;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public List<Status> GetAllStatus()
        {
            try
            {

                List<Status> Statuses = new List<Status>();

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"ID_Position\", \"Name\" FROM public.\"Status\";", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Statuses.Add(new Status(Reader.GetInt64(0), Reader.GetInt64(1), Reader.GetString(2)));
                            }
                        }
                    }

                    Connect.Close();
                }

                return Statuses;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                List<Role> Roles = GetAllRole();
                List<Status> Statuses = GetAllStatus();
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();
                    using (var Command = new NpgsqlCommand($"SELECT public.\"User\".\"ID\", public.\"User\".\"ID_Position\", public.\"User\".\"DateCreate\"," +
                                                                  $"public.\"User\".\"Name\", public.\"User\".\"MidName\", public.\"User\".\"SurName\"," +
                                                                  $"public.\"DataReg\".\"Login\",public.\"DataReg\".\"HashPass\",public.\"DataReg\".\"UpdPassword\"" +
                                                           "FROM public.\"User\", public.\"DataReg\"" +
                                                           "WHERE public.\"User\".\"ID\" = public.\"DataReg\".\"ID\" AND \"User\".\"ID_Position\"='2' ;", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Int64 ID = Reader.GetInt64(0);
                                users.Add(new User(ID, Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetDateTime(2), Roles, Reader.GetInt64(1), Reader.GetString(6), Reader.GetString(7), Reader.GetBoolean(8), Statuses));
                            }
                        }
                    }

                    Connect.Close();
                }

                return users;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public Boolean UpdatePasswordText(String Password, User User)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"UPDATE public.\"DataReg\" " +
                                                            $"SET \"HashPass\" = '{Password}' " +
                                                            $"WHERE \"ID\" = {User.ID}; ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }

        public bool UpdatePassword(User User, Boolean Status)
        {
            try
            {

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"UPDATE public.\"DataReg\" " +
                                                            $"SET \"UpdPassword\" = {Status} " +
                                                            $"WHERE \"ID\" = {User.ID}; ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public Int64 GetAutoIDDrawing()
        {
            try
            {
                Int64 Index = 0;
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT last_value FROM \"Orders_ID_seq\"", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Index = Reader.GetInt64(0);
                            }
                        }
                    }
                }
                return Index;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool CanceledDrawing(Drawing Drawing)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"UPDATE public.\"Orders\" SET \"Canceled\" = {true}" +
                                                           $" WHERE \"Number\" = {Drawing.Order} AND \"List\" = {Drawing.List};", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Drawing> GetCanceledDrawings(string List, string Number)
        {
            try
            {
                List<Drawing> drawings = new List<Drawing>();
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"Number\",\"Mark\", \"List\" FROM public.\"Orders\" WHERE(\"List\" NOT LIKE '%{List + "и"}' OR \"List\"='{List}') AND \"Number\"='{Number}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                drawings.Add(new Drawing { Order = Reader.GetString(0), Mark = Reader.GetString(1), List = Reader.GetString(2) });
                            }
                        }
                    }

                    Connect.Close();
                }

                return drawings;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public Int32 CheckedDrawing(Drawing Drawing)
        {
            try
            {
                int flag = -1;
                String[] Temp = Drawing.List.Split('и');
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT COUNT(\"ID\") FROM public.\"Orders\" WHERE \"List\" = '{Drawing.List}' AND \"Number\"='{Drawing.Order}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                if (Reader.GetInt64(0) == 0)
                                {
                                    if (Temp.Length != 1)
                                    {
                                        if (CheckedFirstCancelledOrder(Drawing.Order, Temp[0]))
                                        {
                                            if (MessageBox.Show("Заменяемый чертеж отсутсвует. Добавить новый?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                            {
                                                flag = 2;
                                            }
                                        }
                                        else
                                        {
                                            flag = 2;
                                        }
                                    }
                                    else
                                    {
                                        flag = 0;
                                    }
                                }
                                else if (CheckedDataMatrixUpdate(Drawing))
                                {
                                    flag = 3;
                                }
                                else
                                {
                                    flag = 1;
                                }
                            }
                        }
                    }

                    Connect.Close();
                }
                return flag;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private bool CheckedFirstCancelledOrder(String Number, String List)
        {
            bool flag = false;
            using (var Connect = new NpgsqlConnection(db.ToString()))
            {
                Connect.Open();
                using (var Command = new NpgsqlCommand($"SELECT COUNT(\"ID\") FROM public.\"Orders\" WHERE \"Number\"='{Number}' AND (\"List\" = '{List}' OR \"List\" LIKE '{List + "и%"}');", Connect))
                {
                    using (var Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            if (Reader.GetInt64(0) == 0)
                            {
                                flag = true;
                            }
                        }
                    }
                }
                Connect.Close();
            }
            return flag;
        }
        private bool CheckedDataMatrixUpdate(Drawing Drawing)
        {
            bool flag = false;
            using (var Connect = new NpgsqlConnection(db.ToString()))
            {
                Connect.Open();
                using (var Command = new NpgsqlCommand($"SELECT COUNT(\"ID\") FROM public.\"Orders\" WHERE \"Number\"='{Drawing.Order}' AND \"List\"='{Drawing.List}' AND \"Mark\"='{Drawing.Mark}' AND \"Executor\"='{Drawing.Executor}' AND \"Lenght\"='{Drawing.SubTotalLenght}' AND \"Weight\"='{Drawing.SubTotalWeight}';", Connect))
                {
                    using (var Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            if (Reader.GetInt64(0) == 0)
                            {
                                flag = true;
                            }
                        }
                    }
                }
                Connect.Close();
            }
            return flag;
        }
        public String GetDataMatrix(String Number, String List)
        {
            String DataMatrix = "";
            using (var Connect = new NpgsqlConnection(db.ToString()))
            {
                Connect.Open();
                using (var Command = new NpgsqlCommand($"SELECT \"Number\",\"List\",\"Mark\",\"Executor\",\"Lenght\",\"Weight\" FROM public.\"Orders\" WHERE  \"Number\"='{Number}' AND \"List\" = '{List}';", Connect))
                {
                    using (var Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            DataMatrix = $"{Reader.GetString(0)}_{Reader.GetString(1)}_{Reader.GetString(2)}_{Reader.GetString(3)}_{Reader.GetString(4)}_{Reader.GetString(5)}";
                        }
                    }
                }
                Connect.Close();
            }
            return DataMatrix;
        }
        public bool CheckedNumberAndMark(String Number, String Mark)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT COUNT(\"ID\") FROM public.\"Orders\" WHERE \"Mark\" = '{Mark}' AND \"Number\"='{Number}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                if (Reader.GetInt64(0) == 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }

                    Connect.Close();
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertDrawing(Drawing Drawing)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"Orders\"(" +
                                                            "\"DateCreate\", \"Executor\", \"Number\", \"List\", \"Mark\", \"Lenght\", \"Weight\", \"Canceled\",\"ID_TypeAdd\",\"ID_Model\" )" +
                                                            $"VALUES('{DateTime.Now}', '{Drawing.Executor}', '{Drawing.Order}', '{Drawing.List}', '{Drawing.Mark}', '{Drawing.SubTotalLenght}', '{Drawing.SubTotalWeight}', {false},'{Drawing.TypeAdd.Id}','{Drawing.Model.Id}');", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public Int64 GetAutoIDDetail()
        {
            try
            {
                Int64 Index = 0;
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT last_value FROM \"Detail_ID_seq\"", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Index = Reader.GetInt64(0);
                            }
                        }
                    }
                }
                return Index;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool InsertDetail(Detail Detail)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"Detail\"(\"Position\",\"Count\",\"Profile\",\"Width\",\"Lenght\",\"Weight\",\"Height\",\"Diameter\",\"SubtotalWeight\",\"MarkSteel\",\"Discription\",\"Machining\", \"MethodOfPaintingRAL\", \"PaintingArea\",\"GostName\",\"FlangeThickness\",\"PlateThickness\") " +
                        $"VALUES('{Detail.Position}','{Detail.Count}','{Detail.Profile}','{Detail.Width}','{Detail.Lenght}','{Detail.Weight}','{Detail.Height}','{Detail.Diameter}','{Detail.SubtotalWeight}','{Detail.MarkSteel}','{Detail.Discription}','{Detail.Machining}', '{Detail.MethodOfPaintingRAL}', '{Detail.PaintingArea}','{Detail.GostName}','{Detail.FlangeThickness}','{Detail.PlateThickness}'); ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool InsertAddDetail(Drawing Drawing, Detail Detail)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"AddDetail\"(\"DateCreate\", \"OrderID\", \"DetailID\") VALUES('{DateTime.Now}', '{Drawing.Id}', '{Detail.ID}'); ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool StatusExist(Drawing Drawing, User User)
        {
            Boolean flag = false;
            try
            {

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"DateCreate\", \"ID_Status\", \"ID_Order\", \"ID_User\" FROM public.\"AddStatus\" WHERE \"ID_Status\"='{User.StatusesUser.First().ID}' AND \"ID_Order\"='{Drawing.Id}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                flag = true;
                            }
                        }
                    }

                    Connect.Close();
                }

                return flag;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool InsertStatus(Drawing Drawing, User User)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"AddStatus\" (\"DateCreate\", \"ID_Status\", \"ID_Order\", \"ID_User\") VALUES('{DateTime.Now}', '{User.StatusesUser.First().ID}', '{Drawing.Id}', '{User.ID}'); ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool DownGradeStatus(Drawing Drawing, User User)
        {
            try
            {
                Int64 ID = GetIDDrawing(Drawing.Order, Drawing.List);

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"DELETE FROM public.\"AddStatus\" WHERE \"ID_Order\"='{ID}' AND \"ID_Status\">='{1}';", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"AddStatus\" (\"DateCreate\", \"ID_Status\", \"ID_Order\", \"ID_User\") VALUES('{DateTime.Now}', '{1}', '{ID}', '{User.ID}'); ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }
                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool UpdateDrawing(Drawing Drawing)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"UPDATE public.\"Orders\" SET \"Executor\" = '{Drawing.Executor}', \"Number\" = '{Drawing.Order}', \"List\" = '{Drawing.List}', \"Mark\" = '{Drawing.Mark}', \"Lenght\" = '{Drawing.SubTotalLenght}', \"Weight\" = '{Drawing.SubTotalWeight}' WHERE \"ID\" = '{GetIDDrawing(Drawing.Order, Drawing.List)}'; ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public Int64 GetIDDrawing(String Number, String List)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\" FROM public.\"Orders\" WHERE \"List\" = '{List}' AND \"Number\"='{Number}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                return Reader.GetInt64(0);
                            }
                        }
                    }

                    Connect.Close();
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        public Model GetModel(Model Model)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"DateCreate\", \"Path\" FROM public.\"Model\" WHERE \"Path\"='{Model.Path}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                Model = new Model { Id = Reader.GetInt64(0), DateCreate = Reader.GetDateTime(1), Path = Reader.GetString(2) };
                            }
                        }
                    }

                    Connect.Close();
                }

                return Model;
            }
            catch (Exception E)
            {
                throw new Exception(E.ToString());
            }
        }
        public bool ModelExist(Model Model)
        {
            Boolean flag = false;
            try
            {

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"DateCreate\", \"Path\" FROM public.\"Model\" WHERE \"Path\"='{Model.Path}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                flag = true;
                            }
                        }
                    }

                    Connect.Close();
                }

                return flag;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool InsertModel(Model Model)
        {
            try
            {
                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"INSERT INTO public.\"Model\"(\"DateCreate\", \"Path\") VALUES('{Model.DateCreate}', '{Model.Path}'); ", Connect))
                    {
                        Command.ExecuteNonQuery();
                    }

                    Connect.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public TypeAdd GetTypeAdd(string Discription)
        {
            try
            {
                TypeAdd TypeAdd = new TypeAdd();

                using (var Connect = new NpgsqlConnection(db.ToString()))
                {
                    Connect.Open();

                    using (var Command = new NpgsqlCommand($"SELECT \"ID\", \"DateCreate\", \"Discription\" FROM public.\"TypeAdd\" WHERE \"Discription\"='{Discription}';", Connect))
                    {
                        using (var Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                TypeAdd = new TypeAdd { Id = Reader.GetInt64(0), DateCreate = Reader.GetDateTime(1), Discription = Reader.GetString(2) };
                            }
                        }
                    }

                    Connect.Close();
                }

                return TypeAdd;
            }
            catch (Exception E)
            {
                throw new Exception(E.ToString());
            }
        }
    }
}
