import { Router } from 'express';
import {
    getTopUsers,
    getTopPT,
    getTopGadgets
} from "../helpers/stat.js"

const router = Router();

//Top 3 users: getTopUsers()
router.get("/", async (req, res) => {
    try {
        const data = await getTopUsers();
        if (!data) {
            res.status(404).json({
                msg: "No se encontró la información solicitada"
            });
            return;
        }
        res.status(200).json(data);
    } catch (error) {
        console.log("Error: ", error);
        res.status(500).json({
            msg: "Error", error,
        });
    }
});

//Ranking of playertypes: getTopPT()
router.get("/", async (req, res) => {
    try {
        const data = await getTopPT();
        if (!data) {
            res.status(404).json({
                msg: "No se encontró la información solicitada"
            });
            return;
        }
        res.status(200).json(data);
    } catch (error) {
        console.log("Error: ", error);
        res.status(500).json({
            msg: "Error", error,
        });
    }
});

//Top 3 users gadgets: getTopGadgets()
router.get("/", async (req, res) => {
    try {
        const data = await getTopGadgets();
        if (!data) {
            res.status(404).json({
                msg: "No se encontró la información solicitada"
            });
            return;
        }
        res.status(200).json(data);
    } catch (error) {
        console.log("Error: ", error);
        res.status(500).json({
            msg: "Error", error,
        });
    }
});

export default router;