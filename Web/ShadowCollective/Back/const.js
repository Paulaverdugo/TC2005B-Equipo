
export const PROD = {
    host: "scollectivedb.caqxtnetpk9j.us-east-2.rds.amazonaws.com",
    user: "scollective",
    password: "scollectivemaster",
    database: "scollective",
 };

export const DEV = {
    host: "localhost",
    user: "scollective",
    password: "Micosis_22",
    database: "scollective",
 };

export const ENV = DEV;
export const PORT = process.env.PORT || 4000;
