import axios from "axios";
import { Permission } from "./models/Permission";

const instance = axios.create({
  baseURL: "https://localhost:56186",
});

const fetchPermissions =  async (): Promise<Permission[]> => {
    try {
        const response = await instance.get("/permission");
        return response.data as Permission[];
      } catch (error) {
        console.error("Error fetching permission:", error);
        return [];
      }
};

export default fetchPermissions;