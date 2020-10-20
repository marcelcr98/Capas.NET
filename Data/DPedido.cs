using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DPedido
    {
        public List<Pedido> GetPedidos(Pedido pedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Pedido> pedidos = null;

            try
            {
                comandText = "USP_FECHAFECHA";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Fec1", SqlDbType.DateTime);
                parameters[0].Value = pedido.FechaInicio;
                parameters[1] = new SqlParameter("@Fec2", SqlDbType.DateTime);
                parameters[1].Value = pedido.FechaFin;
                pedidos = new List<Pedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "USB_FECHAFECHA", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new Pedido
                        {
                            IdPedido = reader["idPedido"] == null ? Convert.ToInt32(reader["idPedido"]) : 0,
                            IdCliente = reader["idCliente"] == null ? Convert.ToString(reader["idCliente"]) : string.Empty,
                            IdEmpleado = reader["idEmpleado"] == null ? Convert.ToInt32(reader["idEmpleado"]) : 0,
                            FechaPedido = reader["FechaPedido"] == null ? Convert.ToDateTime(reader["FechaPedido"]) : DateTime.MinValue,
                            FechaEntrega = reader["FechaEntrega"] == null ? Convert.ToDateTime(reader["FechaEntrega"]) : DateTime.MinValue,
                            FechaEnvio = reader["FechaEnvio"] == null ? Convert.ToDateTime(reader["FechaEnvio"]) : DateTime.MinValue,
                            FormaEnvio = reader["FormaEnvio"] == null ? Convert.ToInt32(reader["FormaEnvio"]) : 0,
                            Cargo = reader["Destinario"] == null ? Convert.ToInt32(reader["Cargo"]) : 0,
                            Destinario = reader["Destinario"] == null ? Convert.ToString(reader["Destinario"]) : string.Empty,
                            DireccionDestinario = reader["CiudadDestinario"] == null ? Convert.ToString(reader["CiudadDestinario"]) : string.Empty,
                            RegionDestinario = reader["RegionDestinario"] == null ? Convert.ToString(reader["RegionDestinario"]) : string.Empty,
                            PaisDestinario = reader["PaisDestinario"] == null ? Convert.ToString(reader["PaisDestinario"]) : string.Empty,
                            CodPostalDestinario = reader["CodPostalDestinario"] == null ? Convert.ToString(reader["CodPostalDestinario"]) : string.Empty,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pedidos;
        }
    }
}