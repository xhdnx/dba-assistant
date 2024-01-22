import axios from "axios"

export default class CommonInfoService {
    static async getAllMetrics(){
        return await axios.get("https://localhost:5006/ExecuteQuery/api/v1")
        .then(function(response){
            return response.data
        })
        .catch(function(error) {
            //TODO: Реализовать адекватную обработку catch 
            console.log(error)
        })
    }

    static async getMetricByQueryName(queryName){
        return await axios.get("https://localhost:5006/ExecuteQuery/api/v1" + String(queryName))
        .then(function(response){
            return response.data
        })
        .catch(function(error) {
            //TODO: Реализовать адекватную обработку catch 
            console.log(error)
        })
    }
}