// src/types/index.ts
export interface NewKidDto {
  birthDate: string;
  email?: string;
  name?: string;
  gender?: string;
}

export interface KidDto extends NewKidDto {
  id: number;
}
