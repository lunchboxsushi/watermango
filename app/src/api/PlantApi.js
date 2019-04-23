import axios from 'axios'

export default class {
    static async getPlants() {
        const result = await axios.get('/api/plant/GetPlants');
        return result.data;
    }

    static async startWatering(plants) {
        return await axios.post('/api/plant/StartWatering', plants);
    }

    static async stopWatering(plants) {
        return await axios.post('/api/plant/StopWatering', plants);
    }
}