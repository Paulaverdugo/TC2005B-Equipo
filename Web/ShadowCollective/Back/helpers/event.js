import connectDB from "../index.js";


//Create Win (ID, user_name, player_type)
export async function addWin(user_name, player_type) {
    const db = await connectDB();

    const [res] = await db.execute(
        `INSERT INTO scollective.WINS(user_name, player_type) VALUES(\'${user_name}\', \'${player_type}\')`
    );

    db.end();
    return res
}

//Create Deads (user_name, player_type, level_dead)
export async function addDeath(user_name, player_type, level_death) {
    const db = await connectDB();

    const [res] = await db.execute(
        `INSERT INTO scollective.DEADS(user_name, player_type, level_dead) VALUES(\'${user_name}\', \'${player_type}\', \'${level_death}\')`
    );

    db.end();
    return res
}