import React, { useState } from "react"
import cl from './css/tables.module.css'
import { Button, Table } from "react-bootstrap"
import CommonInfoService from "../../API/CommonInfoAboutDBs"


const TemplateTable = ({title, data}) => {
    
    const editQueryText = () => {

    }

    const copySQLQueryText = () => {

    }

    async function reload (queryName) {

    }

    if (data.length > 0){
        
        const tableHeader = Object.keys(data[0]).map((key, index) =>(
            <td>
                {key}
            </td>
        ))
        
        const tableBody = data.map((dictionary) => (
            <tr>
                {Object.entries(dictionary).map(([key, value]) =>(
                    <td key={key}>
                        {value}
                    </td>
                ))}
            </tr>
        ))
        
        return (
            <div className={cl.table}>
                <Table striped bordered responsive size="sm" className={cl.templateTable}>
                    <caption>
                        <div>
                            <span>{title}</span>
                            <div className={cl.TableBtn}>
                                <Button 
                                    className={cl.smallBtn}
                                    onClick={() => reload()}>
                                    Обновить
                                </Button>
                                <Button 
                                    className={cl.smallBtn}
                                    onClick={copySQLQueryText}>
                                    Скопировать запрос
                                </Button>
                                <Button 
                                    className={cl.smallBtn}
                                    onClick={editQueryText}>
                                    Редактировать запрос
                                </Button>
                            </div>
                        </div>
                    </caption>
                    <thead id={cl.head}> 
                        <tr>
                            {tableHeader}
                        </tr>
                    </thead>
                    <tbody>
                        {tableBody}
                    </tbody>
                </Table>
            </div>
            
        ) 
    }

    return (
        <div className={cl.table}>
            <div className={cl.emptyBlock}>
                <span>{title}</span>
                <section className={cl.TableBtn}>
                    <Button 
                        className={cl.smallBtn}
                        onClick={reload}>
                        Обновить
                    </Button>
                    <Button 
                        className={cl.smallBtn}
                        onClick={copySQLQueryText}>
                        Скопировать запрос
                    </Button>
                    <Button 
                        className={cl.smallBtn}
                        onClick={editQueryText}>
                        Редактировать запрос
                    </Button>
                </section>
            </div>
        </div>
    ) 
    
}

export default TemplateTable