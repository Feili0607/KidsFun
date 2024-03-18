// src/api/kidsApi.ts
import axios from 'axios';
import { NewKidDto } from '../types';

const BASE_URL = 'https://localhost:7294';

export const fetchKids = async () => {
  return axios.get(`${BASE_URL}/Kid`);
};

export const createKid = async (newKidData: NewKidDto) => {
  return axios.post(`${BASE_URL}/Kid`, newKidData);
};
