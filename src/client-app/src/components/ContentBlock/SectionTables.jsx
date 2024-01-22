import React from "react"
import TemplateTable from "./TemplateTable"

const SectionTables = (data) =>{

    const getDeserializeData = (rawData) => {
        return JSON.parse(rawData)
    }
    console.log(data)
    return (
        <div>
             {Object.entries(Object.entries(data)[0][1]).map(([key, value]) => (
                <TemplateTable key={key} title={key} data={getDeserializeData(value)}></TemplateTable>
            ))}
        </div>
    )

}


export default SectionTables

