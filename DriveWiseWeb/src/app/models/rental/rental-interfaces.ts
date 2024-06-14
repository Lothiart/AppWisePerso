export interface VehicleBase {
  registration: string;
  totalSeats: number;
  co2EmissionKm: number;
}

export interface VehicleAddDto extends VehicleBase {
  categoryId: number;
  motorId: number;
  modelId: number;
}

export interface VehicleAdminDto extends VehicleAddDto {
  statusId: number;
}

export interface VehicleByDateDto {
  startDate: Date;
  endDate: Date;
}

export interface VehicleGetDto extends VehicleBase {
  id: number;
}

export interface VehicleRentalDto extends VehicleGetDto {
  startDate: Date;
  endDate: Date;
}

export interface VehicleTempDto extends VehicleGetDto {
  categoryName: string;
  motorType: string;
  modelName: string;
  brandName: string;
}

export interface VehicleUpdateDto extends VehicleAdminDto {
  id: number; 
}
